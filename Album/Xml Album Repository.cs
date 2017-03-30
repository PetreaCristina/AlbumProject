using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AlbumProject
{
    class Xml_Album_Repository : AlbumRepository
    {
        public override StringBuilder Commit()
        {
            StringBuilder textXml = new StringBuilder("");
            List<Album> albums = GetAll();
            textXml = textXml.Append("<albums>\r\n\n");
            foreach(var item in albums)
            {
                textXml.Append("\t<album>\r\n");
                textXml.Append("\t\t<ID>"+item.Id+ "</ID>\r\n");
                textXml.Append("\t\t<Name>"+item.Name+ "</Name>\r\n");
                textXml.Append("\t\t<Artist>"+item.Artist+ "</Artist>\r\n");
                textXml.Append("\t\t<Release Date>"+item.ReleaseDate+ "</ReleaseDate>\r\n");
                textXml.Append("\t\t<Number Of Songs>"+item.NoSongs+ "</Number Of Songs>\r\n");
                textXml.Append("\t\t<Description>"+item.Description+ "</Description>\r\n");
                textXml.Append("\t\t<Gen>"+item.Gen+ "</Gen>\r\n");
                textXml.Append("\t\t<Price>"+item.Price+ "</Price>\r\n");
                textXml.Append("\t</album>\r\n\n");
            }
            textXml.Append("</albums>");
            return textXml;

        }
        public override void Load(string path)
        {
            string filePath = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory) + "\\" + path;
            var xml = XDocument.Load(path);
            int outputForInt = 0;
            var query = from c in xml.Root.Descendants("Album")
                        select new Album()
                        {
                            Id = (c.Element("Id") != null) ? (int.TryParse(c.Element("Id").Value, out outputForInt) ? outputForInt : GetLastId()+1) : GetLastId()+1,
                            Name = c.Element("Name").Value,
                            Artist = c.Element("Artist").Value,
                            Gen = c.Element("Gen").Value,
                            NoSongs = (c.Element("NoSongs") != null) ? (int.TryParse(c.Element("NoSongs").Value, out outputForInt) ? outputForInt : 0) : 0 + 1,
                            Description = c.Element("Description").Value,    
                            Price = (c.Element("Price") != null) ? (int.TryParse(c.Element("Price").Value, out outputForInt) ? outputForInt : 0) : 0 + 1,
                            ReleaseDate = Convert.ToDateTime(GetDate(c.Element("ReleaseDate").Value)),
                        };
            foreach(var item in query)
            {
                Add(item);
            }
           
    
        }
        private DateTime GetDate(string value)
        {
            var x = value.Split('.');
            int day=int.Parse(x[0]);
            int month = int.Parse(x[1]);
            int year=int.Parse(x[2]);
            var data = new DateTime(year,month,day);
            return data;
        }
    }
}
