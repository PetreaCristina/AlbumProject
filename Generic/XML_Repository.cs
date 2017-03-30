using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace AlbumProject
{
    class XML_Repository<T> : Repository<T> where T : BaseEntity,new ()
    {
        public override StringBuilder Commit()
        {
            StringBuilder textXml = new StringBuilder("");
            List<T> objects = GetAll();
            using (XmlWriter writer = XmlWriter.Create("outputXmlGeneric.xml"))
            {
                writer.WriteStartDocument();
                var className = Items[0].GetType().Name;
                textXml.Append("<"+className+"s>\n");
                foreach (var item in Items)
               {         
                    textXml.Append("\t<"+className+">");
                    var prop=item.GetType().GetProperties();
                    foreach(var property in item.GetType().GetProperties())
                    {
                        var name = property.Name;
                        var val = property.GetValue(item);
                        textXml.Append("\n\t\t");
                        textXml.Append("<"+name+">");
                        textXml.Append(val);
                        textXml.Append("</"+name+">");
                        textXml.Append("\t\t");
                    }
                    textXml.Append("\n\t"); 
                   
                    textXml.Append("</" + className + ">\n");
                }
                textXml.Append("</" + className + "s>");
            }
            return textXml;              
        }

        public override void Load(string path)
        {
                XmlDocument document = new XmlDocument();
                document.Load(path);
                //Gets all the tags with tag name row
                XmlNodeList nodeList = document.GetElementsByTagName(new T().GetType().Name);
                //Loop through each and every node
                foreach (XmlNode node in nodeList)
                {
                    T tObject = new T();
                    foreach (XmlNode xmlAtr in node.ChildNodes)
                    {
                        tObject.GetType().GetProperty(xmlAtr.Name).SetValue(tObject, Convert.ChangeType( xmlAtr.InnerText, tObject.GetType().GetProperty(xmlAtr.Name).PropertyType));
                    }
                    Items.Add(tObject);
                }
            
        }
    }
}
