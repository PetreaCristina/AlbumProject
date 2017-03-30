using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumProject
{
    class CSV_Album_Repository : AlbumRepository
    {
        public override StringBuilder Commit()
        {
            StringBuilder text = new StringBuilder("");
            StringBuilder header = new StringBuilder("id, name, artist, release date,no_songs,description,gen,price");
            text = header.Append("\r\n");
            foreach (var item in Albums)
            {
                var sb = new StringBuilder();
                sb.Append(item.ReleaseDate.ToString("dd.MM.yyyy"));
                foreach (var property in item.GetType().GetProperties())
                {
                    if (property.PropertyType == typeof(DateTime))
                    {
                        string day = ((DateTime)property.GetValue(item, null)).Day.ToString() + ".";
                        string month = ((DateTime)property.GetValue(item, null)).Month.ToString() + ".";
                        string year = ((DateTime)property.GetValue(item, null)).Year.ToString() + ",";
                        text.Append(day + month + year);
                    }
                    else
                    {
                        if ((property.PropertyType == typeof(Decimal)))
                        {
                            text.Append(property.GetValue(item)+",");
                        }
                        else
                        {
                            text.Append(property.GetValue(item, null) + ",");
                        }
                    }
                }
                text.Length--;
               text.Append("\r\n");
            }
            return text;
        }
        public override void Load(string path)
        {
            string[] lines;
            if (File.Exists(path))
            {
                string readText = File.ReadAllText(path);
                string stringId;
                string nameCsv;
                string releaseDateCvs;
                DateTime releaseDateTimeCvs;
                string stringNoSongs;
                int noSongsCvs;
                string descriptionCvs;
                string genCvs;
                decimal priceCvs;
                string stringPriceCvs;
                int indexofG = readText.IndexOf('"');
                lines = readText.Split('\n');
                for (int i = 1; i < lines.Length; i++)
                {
                    Album newAlbum = new AlbumProject.Album();
                    //id
                    stringId = lines[i].Substring(0, lines[i].IndexOf(','));
                    newAlbum.Id = int.Parse(stringId);
                    lines[i] = lines[i].Remove(0, lines[i].IndexOf(',') + 1);

                    //name
                    nameCsv = lines[i].Substring(1, lines[i].IndexOf('"', 1) - 1);
                    newAlbum.Name = nameCsv;
                    lines[i] = lines[i].Remove(0, lines[i].IndexOf('"', 2) + 2);

                    //artist
                    newAlbum.Artist = lines[i].Substring(1, lines[i].IndexOf('"', 1) - 1);
                    lines[i] = lines[i].Remove(0, lines[i].IndexOf('"', 2) + 2);

                    //release date
                    releaseDateCvs = lines[i].Substring(0, lines[i].IndexOf(','));
                    releaseDateTimeCvs = Convert.ToDateTime(releaseDateCvs);
                    newAlbum.ReleaseDate = releaseDateTimeCvs;   
                    lines[i] = lines[i].Remove(0, lines[i].IndexOf(',') + 1);

                    //no songs
                    stringNoSongs = lines[i].Substring(0, lines[i].IndexOf(','));
                    noSongsCvs = int.Parse(stringNoSongs);
                    newAlbum.NoSongs = noSongsCvs;
                    lines[i] = lines[i].Remove(0, lines[i].IndexOf(',') + 1);

                    //description
                    descriptionCvs = lines[i].Substring(1, lines[i].IndexOf('"', 1) - 1);
                    newAlbum.Description = descriptionCvs;
                    lines[i] = lines[i].Remove(0, lines[i].IndexOf('"', 2) + 2);

                    //gen
                    genCvs = lines[i].Substring(1, lines[i].IndexOf(',', 1) - 2);
                    newAlbum.Gen = genCvs;
                    lines[i] = lines[i].Remove(0, lines[i].IndexOf('"', 2) + 2);

                    //price
                    try
                    {
                        stringPriceCvs = lines[i];
                        decimal.TryParse(stringPriceCvs, out priceCvs);
                        newAlbum.Price = priceCvs;
                    }
                    catch
                    {
                        stringPriceCvs = lines[i].Substring(0);
                        priceCvs = int.Parse(stringPriceCvs);
                        newAlbum.Price = priceCvs;
                    }
                    Albums.Add(newAlbum);
                }

            }

        }

    }
}
