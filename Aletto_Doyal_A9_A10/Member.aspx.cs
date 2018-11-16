using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Aletto_Doyal_A9_A10
{
    public partial class Main : System.Web.UI.Page
    {
        private accessType AccessType;

        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (Request.Browser.Cookies && !IsPostBack)
            {
                HttpCookie hasCookie = Request.Cookies["AD_598"];
                if ((hasCookie == null) || (hasCookie["Name"] == ""))
                {
                    Response.Redirect("Login.aspx");
                }
                else if (hasCookie.Values.Get("SessionId").ToString() != Session.SessionID
                        || hasCookie.Values.Get("LoggedIn").ToString() != "True")
                {
                     Response.Redirect("Login.aspx");
                }
            }
        }


        /// <summary>
        /// Button actions for getting location information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGetAltFuelAtLocation_Click(object sender, EventArgs e)
        {
            //Grab location information and radius
            string radius = String.Empty;
            if (String.IsNullOrWhiteSpace(txtbxRadiusLocation.Text))
            {
                txtarLocationOutput.InnerText = "A search radius must be provided!";
                return;
            }
            else
            {
                radius = txtbxRadiusLocation.Text;
            }
            string address = txtbxAddressLocationInput.Text;
            string city = txtbxCityLocationInput.Text;
            string state = String.Empty;
            if (drpdnStateLocation.Text != "None Selected")
            {
                state = drpdnStateLocation.Text;
            }
            string zipcode = txtbxZipcodeLocation.Text;


            //Call to service from project 3 (get coordinate location)
            string url = @"http://webstrar43.fulton.asu.edu/page7/Service.svc/GetLocation?address=" + address + "&city=" + city + "&state=" + state + "&zipcode=" + zipcode;

            //Encodes string for proper format when using as a URL
            System.Web.HttpUtility.UrlEncode(url);

            string xmlString = Get(url);

            XmlReader reader = XmlReader.Create(new StringReader(xmlString)); //Create a reader for the returning XML document
            bool boolean = false; //Flag used in exiting loop
            string coordinate = String.Empty;

            //Loop used to locate section of XML document that contains the data needed
            while (!boolean && reader.Read())
            {
                if (reader.LocalName == "string")
                {
                    boolean = true;
                    coordinate = reader.ReadElementContentAsString();
                }
            }

            coordinate = coordinate.Replace(" ",",");

            //Key to online service
            string key = "Ainae0P5Jbzp5UAnsKLAwK3hBl6n7APKzsFygH7mSIy9djtUZYEdvkV-2GvxHjoa";
            url = @"http://dev.virtualearth.net/REST/v1/Locations/" + coordinate + "?o=xml&includeEntityTypes=Postcode1&key=" + key;

            //Encodes string for proper format when using as a URL
            System.Web.HttpUtility.UrlEncode(url);

            //Perform call to convert coordinate to zipcode service
            xmlString = Get(url);
            XmlReader reader_2 = XmlReader.Create(new StringReader(xmlString)); //Create a reader for the returning XML document
            boolean = false; //Flag used in exiting loop
            string fZipcode = String.Empty; //Zipcode sent to alt fuel station service

            //Loop used to locate section of XML document that contains the data needed
            while (!boolean && reader_2.Read())
            {
                if (reader_2.LocalName == "PostalCode")
                {
                    boolean = true;
                    fZipcode = reader_2.ReadElementContentAsString();
                }
            }

            //Make url for use in call to fuel service API
            //url = @"http://webstrar43.fulton.asu.edu/page3/Service.svc/GetAFStations?Zip=" + fZipcode + "&Radius=" + radius + "&FuelTypes=ELEC";

            AFServices.ServiceClient proxy = new AFServices.ServiceClient();
            string jsonString = proxy.GetAFStations(fZipcode, "ELEC", Convert.ToInt32(radius));
            //Encodes string for proper format when using as a URL
            //System.Web.HttpUtility.UrlEncode(url);

            //Make call to alt fuel service
            //string jsonString = Get(url);

            //Visual studio does not recognize as a json object. 
            //Create a xml read to pull out the json string
            //XmlReader reader_3 = XmlReader.Create(new StringReader(jsonString));
            //boolean = false; //Flag used in exiting loop

            ////Loop used to locate section of XML document that contains the data needed
            //while (!boolean && reader_3.Read())
            //{
            //    if (reader_3.LocalName == "string")
            //    {
            //        boolean = true;
            //        jsonString = reader_3.ReadElementContentAsString();
            //    }
            //}

            dynamic layer1 = JsonConvert.DeserializeObject(jsonString);
            var tempStations = layer1.AFStations;

            if (tempStations.Count == 0)
            {
                txtarLocationOutput.InnerText = "No Stations Returned...";
                return;
            }

            string result = null; //String used to compile alt fuel stations

            //Loop that fetches all the applicable data
            foreach (var station in tempStations)
            {
                result += ((string)station.Name).ToUpper() + Environment.NewLine;
                result += "        " + (string)station.Address + Environment.NewLine;
                result += "        " + (string)station.City + ", " + (string)station.State + "  ";
                result += "        " + (string)station.Zip + Environment.NewLine;
                result += "        Phone :  " + (string)station.Phone + Environment.NewLine;
                result += "        Acess:  " + (string)station.Access + Environment.NewLine;
                result += "        Fuel Type:  " + (string)station.FuelType + Environment.NewLine;
                result += "        Distance(mi):  " + station.Distance.ToString() + Environment.NewLine;
            }

            txtarLocationOutput.InnerText = result;
        } //End btnGetAltFuelAtLocation_Click

        /// <summary>
        /// Makes a get call to the specified url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string Get(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        } //End Get


        /// <summary>
        /// Button actions for getting routing information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGetAltFuelStationsAlongRoute_Click(object sender, EventArgs e)
        {
            string address_1 = txtbxFromAddressRoute.Text;
            string city_1 = txtbxFromCityRoute.Text;
            string state_1 = String.Empty;
            if (drpdnFromStateRoute.Text != "None Selected")
            {
                state_1 = drpdnFromStateRoute.Text;
            }
            string zipcode_1 = txtbxFromZipcodeRoute.Text;

            string address_2 = txtbxToAddressRoute.Text;
            string city_2 = txtbxToCityRoute.Text;
            string state_2 = String.Empty;
            if (drpdnToStateRoute.Text != "None")
            {
                state_2 = drpdnToStateRoute.Text;
            }
            else
            {
                state_2 = "";
            }
            string zipcode_2 = txtbxToZipcodeRoute.Text;

            string interval = txtbxIntervalRoute.Text;
            if (String.IsNullOrWhiteSpace(interval))
            {
                txtarRouteOutput.InnerText = "Interval value is required!";
                return;
            }

            string url = @"http://webstrar43.fulton.asu.edu/page7/Service.svc/GetIntervalRouteBtwn2Locations?address_1=" + address_1 + "&city_1=" + city_1 + "&state_1=" + state_1 + "&zipcode_1=" + zipcode_1 + "&address_2=" + address_2 + "&city_2=" + city_2 + "&state_2=" + state_2 + "&zipcode_2=" + zipcode_2 + "&interval=" + interval;

            //Encodes string for proper format when using as a URL
            System.Web.HttpUtility.UrlEncode(url);

            string xmlString = Get(url);

            XmlReader reader = XmlReader.Create(new StringReader(xmlString)); //Create a reader for the returning XML document
            bool boolean = false; //Flag used in exiting loop
            string coordinates = String.Empty;

            //Loop used to locate section of XML document that contains the data needed
            while (!boolean && reader.Read())
            {
                if (reader.LocalName == "string")
                {
                    boolean = true;
                    coordinates = reader.ReadElementContentAsString();
                }
            }

            char[] delims = new char[1];
            delims[0] = ',';

            //Split each coordinate up
            string[] coords = coordinates.Split(delims);

            //Put a comma between each long and lat pair
            for(int i = 0; i < coords.Length; i++)
            {
                coords[i] = coords[i].Replace(" ",",");
            }

            //Make an array to hold the incoming zipcodes
            string[] zipcodes = new string[coords.Length];

            //Key to online service
            string key = "Ainae0P5Jbzp5UAnsKLAwK3hBl6n7APKzsFygH7mSIy9djtUZYEdvkV-2GvxHjoa";

            //Make sequential calls for zipcodes
            for (int i = 0; i < coords.Length; i++)
            {
                
                url = @"http://dev.virtualearth.net/REST/v1/Locations/" + coords[i] + "?o=xml&includeEntityTypes=Postcode1&key=" + key;

                //Encodes string for proper format when using as a URL
                System.Web.HttpUtility.UrlEncode(url);

                //Perform call to convert coordinate to zipcode service
                xmlString = Get(url);
                XmlReader reader_2 = XmlReader.Create(new StringReader(xmlString)); //Create a reader for the returning XML document
                boolean = false; //Flag used in exiting loop

                //Loop used to locate section of XML document that contains the data needed
                while (!boolean && reader_2.Read())
                {
                    if (reader_2.LocalName == "PostalCode")
                    {
                        boolean = true;
                        zipcodes[i] = reader_2.ReadElementContentAsString();
                    }
                }
            } //End for loop getting zipcodes

            Int32 count = 0;
            double radMark = .1;
            double dInterval = 0;
            Double.TryParse(interval, out dInterval);
            string result = String.Empty;
            AFServices.ServiceClient proxy = new AFServices.ServiceClient();

            while (count < zipcodes.Length)
            {

                //Make sure no zipcodes came back null
                while(zipcodes[count] == null)
                {
                    count++;
                }



                //Make url for use in call to fuel service API
                //url = @"http://webstrar43.fulton.asu.edu/page3/Service.svc/GetAFStations?Zip=" + zipcodes[count] + "&Radius=" + ((Int32)(radMark * dInterval)).ToString()  + "&FuelTypes=ELEC";
               // url = @" http://localhost:60159/Service.svc/GetAFStations?Zip=" + zipcodes[count] + "&Radius=" + ((Int32)(radMark * dInterval)).ToString() + "&FuelTypes=ELEC"; 
                //Encodes string for proper format when using as a URL
                //System.Web.HttpUtility.UrlEncode(url);

                //Make call to alt fuel service
               // string jsonString = Get(url);

               // service call.
                string jsonString = proxy.GetAFStations(zipcodes[count], "ELEC", (Int32)(radMark * dInterval));

                //Visual studio does not recognize as a json object. 
                //Create a xml read to pull out the json string
                //XmlReader reader_3 = XmlReader.Create(new StringReader(jsonString));
                //boolean = false; //Flag used in exiting loop

                //Loop used to locate section of XML document that contains the data needed
                //while (!boolean && reader_3.Read())
                //{
                //    if (reader_3.LocalName == "string")
                //    {
                //        boolean = true;
                //        jsonString = reader_3.ReadElementContentAsString();
                //    }
                //}

                dynamic layer1 = JsonConvert.DeserializeObject(jsonString);
                var tempStations = layer1.AFStations;

                if (tempStations.Count == 0 && radMark <= .6)
                {
                    radMark += .1;
                    continue;
                }
                else
                {
                    radMark = .1;
                    count++;
                }

                //Loop that fetches all the applicable data
                foreach (var station in tempStations)
                {
                    result += ((string)station.Name).ToUpper() + Environment.NewLine;
                    result += "        " + (string)station.Address + Environment.NewLine;
                    result += "        " + (string)station.City + ", " + (string)station.State + "  ";
                    result += "        " + (string)station.Zip + Environment.NewLine;
                    result += "        Phone :  " + (string)station.Phone + Environment.NewLine;
                    result += "        Acess:  " + (string)station.Access + Environment.NewLine;
                    result += "        Fuel Type:  " + (string)station.FuelType + Environment.NewLine;
                    result += "        Distance(mi):  " + station.Distance.ToString() + Environment.NewLine;
                    result += "\n";
                    break;
                }

                
            }

            txtarRouteOutput.InnerText += result + "\n";

        }

        protected void exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}