using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace API_Tester
{
    class SingletonXML
    {
        private static readonly Lazy<SingletonXML> lazyInstance = new Lazy<SingletonXML>(() => new SingletonXML());
        private XmlDocument loadedXml;

        // Singleton 인스턴스를 가져오는 속성입니다.
        public static SingletonXML Instance => lazyInstance.Value;


        private SingletonXML()
        {
            this.loadedXml = new XmlDocument();
        }

        // Save_XML이 됐다면 SetXML 해줘야 한다.
        public void SetXML(XmlDocument xml)
        {
            this.loadedXml = xml;
        }

        public XmlDocument GetXML()
        {
            return this.loadedXml;
        }

        public XmlDocument ResetXML()
        {
            XmlDocument xdoc = new XmlDocument();

            XmlNode root = xdoc.CreateElement("Request");
            xdoc.AppendChild(root);

            XmlNode xData = xdoc.CreateElement("Request-Data");

            XmlNode xMethod = xdoc.CreateElement("Method");
            xMethod.InnerText = "GET";
            xData.AppendChild(xMethod);

            XmlNode xUrl = xdoc.CreateElement("URL");
            xUrl.InnerText = "";
            xData.AppendChild(xUrl);

            XmlNode xCookie = xdoc.CreateElement("Cookie");
            xCookie.InnerText = "";
            xData.AppendChild(xCookie);

            XmlNode xMsg = xdoc.CreateElement("Msg");
            xMsg.InnerText = "";
            xData.AppendChild(xMsg);

            root.AppendChild(xData);

            return xdoc;
        }

    }
}
