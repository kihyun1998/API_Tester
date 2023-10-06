using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace API_Tester
{
    class XmlData
    {
        private static readonly Lazy<XmlData> lazyInstance = new Lazy<XmlData>(() => new XmlData());

        // 싱글톤 객체
        private Dictionary<string, XmlDocument> XmlDatas = new Dictionary<string, XmlDocument>();

        // 생성자
        private XmlData()
        {
            this.XmlDatas = new Dictionary<string, XmlDocument>();
        }

        // 불러오는 방법 >  XmlData xmlData = XmlData.Instance;
        public static XmlData Instance => lazyInstance.Value;

        // 초기 데이터 불러와서 객체에 저장
        // 키는 폴더.파일 & 값은 xml
        // 파일 초기 생성 시 사용해야 한다. (Repository.AddFile & Repository.CreateDirectoryNode)
        public void AddData(string key, XmlDocument value)
        {
            this.XmlDatas.Add(key, value);
        }

    }
}
