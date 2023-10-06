using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

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

        // "값" 수정하는 경우 저장
        public void UpdateData(string key, XmlDocument value)
        {
            this.XmlDatas[key] = value;
        }

        // 키를 통해 값 읽기
        public XmlDocument ReadData(string key)
        {
            return this.XmlDatas[key];
        }

        // 값 존재 체크 여부
        public bool IsExist(string key)
        {
            return XmlDatas.ContainsKey(key);
        }

        // 싱글톤 객체 전체 저장
        public void SaveAll()
        {
            foreach (KeyValuePair<string, XmlDocument> data in XmlDatas)
            {
                Form1.form1.Local_Save(data.Key, data.Value);
            }
        }

        // 딕셔너리 값 확인용
        public void ShowData()
        {
            foreach(KeyValuePair<string,XmlDocument> data in this.XmlDatas)
            {
                CustomMessageBox.ShowMessage(string.Format("{0} : {1}", data.Key, data.Value.OuterXml), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
