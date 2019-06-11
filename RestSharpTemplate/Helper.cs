using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpTemplate.DataModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace RestSharpTemplate
{
    public static class Helper
    {
     
        public static Authorisation Authorisation;
        public static RestRequest Request { get; set; }

        public static string Api_Subscription { get; set; }

        public static TestContext TestContext { get; set; }

        public static Authorisation Auth(TestContext context)
        {
            string env = context.Properties["Environment"].ToString();
    
            Authorisation = new Authorisation
            {
                Endpoint = context.Properties[$"{env}:Endpoint"].ToString(),
                Subscription = context.Properties[$"{env}:Subscription"].ToString()
            };

            return Authorisation;
        }

        public static Authorisation NoAuth(TestContext context)
        {
            string env = context.Properties["Environment"].ToString();

            Authorisation = new Authorisation
            {
                Endpoint = context.Properties[$"{env}:Endpoint"].ToString(),
                Subscription = context.Properties["NoSubscription"].ToString()
            };

            return Authorisation;
        }

        public static RestRequest SetUpRequest(string relativeUri, Method methodType, TestContext testContext)
        {
            Request = new RestRequest(relativeUri, methodType);
            Request.AddHeader("Ocp-Apim-Trace", "true");
            Request.AddHeader("Ocp-Apim-Subscription-Key", Auth(testContext).Subscription);
            Request.AddHeader("Content-Type", "application/json;");

            return Request;
        }

        public static string EncodeBase64(string data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(data));
        }

        public static string DecodeBase64(string data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            return Encoding.UTF8.GetString(Convert.FromBase64String(data));
        }

        public static string GetBase64Template(this string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));
            var XMLPath = Path.Combine("Templates", Path.ChangeExtension(fileName, "xml"));
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(XMLPath);

            return EncodeBase64(xDoc.OuterXml);
        }

        public static IEnumerable<string> RequestList(this string fileName)
        {
            var jsonPath = Path.Combine("Templates", Path.ChangeExtension(fileName, "json"));

            return File.ReadLines(jsonPath);
        }

        public static XDocument GetXMLTemplate(this string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));
            var XMLPath = Path.Combine("Templates", Path.ChangeExtension(fileName, "xml"));
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(XMLPath);

            return xDoc.ToXDocument();
        }

        public static XDocument ToXDocument(this XmlDocument xmlDocument)
        {
            using (var nodeReader = new XmlNodeReader(xmlDocument))
            {
                nodeReader.MoveToContent();
                return XDocument.Load(nodeReader);
            }
        }
    }
}
