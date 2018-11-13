﻿using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetAltFuelAtLocation_Click(object sender, EventArgs e)
        {
            //Grab location information and radius
            if (String.IsNullOrWhiteSpace(txtbxRadiusLocation.Text))
            {

            }
            string address = txtbxAddressLocationInput.Text;
            string city = txtbxCityLocationInput.Text;
            string state = String.Empty;
            if (drpdnStateLocation.Text != "None Selected")
            {
                state = drpdnStateLocation.Text;
            }
            string zipcode = txtbxZipcodeLocation.Text;



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

            xmlString = Get(url);
            XmlReader reader_2 = XmlReader.Create(new StringReader(xmlString)); //Create a reader for the returning XML document
            boolean = false; //Flag used in exiting loop
            string fZipcode = String.Empty;

            //Loop used to locate section of XML document that contains the data needed
            while (!boolean && reader_2.Read())
            {
                if (reader_2.LocalName == "PostalCode")
                {
                    boolean = true;
                    fZipcode = reader_2.ReadElementContentAsString();
                }
            }
            txtarLocationOutput.InnerText = fZipcode;
        }

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
    }
}