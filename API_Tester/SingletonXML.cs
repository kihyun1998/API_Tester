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
        private XmlDocument loadXml;

        // Singleton 인스턴스를 가져오는 속성입니다.
        public static SingletonXML Instance => lazyInstance.Value;


        private SingletonXML()
        {
            this.loadXml = new XmlDocument();
        }

        // Save_XML이 됐다면 SetXML 해줘야 한다.
        public void SetXML(XmlDocument xml)
        {
            this.loadXml = xml;
        }

        public XmlDocument GetXML()
        {
            return this.loadXml;
        }
        
    }
}
