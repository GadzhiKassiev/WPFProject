using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WpfApp1.Model
{
    class DataBase
    {

        public static List<Element> GetSortingElementsFromFile()
        {          
            List<Element> arr = new List<Element>();
            XmlReader reader = XmlReader.Create("C:\\Users\\Asus\\source\\repos\\WpfApp1\\XMLWPF.xml");
            while(reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "element" && reader.HasAttributes)
                {
                    arr.Add(new Element { ID = int.Parse(reader.GetAttribute("id")), ElementName = reader.GetAttribute("name") });
                }
            }
            Algorithms.sort(arr.ToArray());
            return arr;
        }

        public static List<Element> GetElementsByOrderFromFile(List<Element> elements)
        {
            List<Element> el = new List<Element>();
            string path = "C:\\Users\\Asus\\source\\repos\\WpfApp1\\TextFileWPF.txt";
            if (new FileInfo(path).Length > 0)
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    Element e = Algorithms.Search(ref elements, int.Parse(line));
                    if (e != null)
                        el.Add(e);
                }
                foreach (Element e in elements)
                    el.Add(e);
                return el;
            }
            return elements;
        }     
    }
}
