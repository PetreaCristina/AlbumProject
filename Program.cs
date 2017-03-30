using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AlbumProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string date = "01/09/2008 14:50:50.42";
            DateTime dateTime = Convert.ToDateTime(date);
            Album Starboy = new Album();
            Album Stargirl = new AlbumProject.Album("Stargirl", Convert.ToDateTime(dateTime),"Stargirll", 9, "lalala", "rock", 8);

            //Album loadExample;
            Starboy.Id = 9;
            Starboy.Name = "3SudEst";
            Starboy.Artist = "The Weeknd";
            Starboy.Gen = "rock";
            Starboy.ReleaseDate = Convert.ToDateTime(dateTime);
            Starboy.Description = "Hello!!";
            Starboy.Price = 8;
            string path = @"C:\Users\EXNintern4\Documents\Visual Studio 2015\Projects\AlbumProject\inputCsv.csv";
            string pathXml = @"C:\Users\EXNintern4\Documents\Visual Studio 2015\Projects\AlbumProject\inputXml.xml";
            string pathCsvArtist= @"C:\Users\EXNintern4\Documents\Visual Studio 2015\Projects\AlbumProject\inputCsvArtist.csv";
            CSV_Album_Repository csvAlbum = new CSV_Album_Repository();
            Xml_Album_Repository xmlAlbum = new Xml_Album_Repository();

            csvAlbum.Add(Starboy);
            csvAlbum.Load(path);
            StringBuilder loadCsv = csvAlbum.Commit();
            Console.WriteLine("-----Load CSV--------");
            Console.WriteLine(loadCsv);

            xmlAlbum.Load(pathXml);
            StringBuilder loadXml = xmlAlbum.Commit();
            Console.WriteLine("-----Load XML--------");
            Console.WriteLine(loadXml);

            using (System.IO.StreamWriter outputFileCSV = new System.IO.StreamWriter(@"C:\Users\EXNintern4\Documents\Visual Studio 2015\Projects\AlbumProject\outputCsv.csv"))
            {
                outputFileCSV.WriteLine(loadCsv);
            }
            using (System.IO.StreamWriter outputFileXml = new System.IO.StreamWriter(@"C:\Users\EXNintern4\Documents\Visual Studio 2015\Projects\AlbumProject\outputXml.xml"))
            {
                outputFileXml.WriteLine(loadXml);
            }

            // Console.WriteLine("-----Commit--------");
            // StringBuilder commitCsv = csvAlbum.Commit();
            //Console.WriteLine(commitCsv);

            Artist Maria = new Artist();
            Maria.Name = "Maria";
            Maria.album = Stargirl;
            Maria.Id = 7;

            CSV_Repository<Artist> csv_artist_generic = new CSV_Repository<Artist>();
            CSV_Repository<Album> csv_album_generic = new CSV_Repository<Album>();
            //csv_album_generic.Add(Starboy);
            // csv_album_generic.Add(Stargirl);
            csv_artist_generic.Add(Maria);
            //Generic Load
            Console.WriteLine("----Generic Load Csv----");
            csv_album_generic.Load(path);
            StringBuilder csvGeneric = csv_album_generic.Commit();
            // StringBuilder csv_artist_generic = csv_artist.Commit();

            Console.WriteLine(csvGeneric);
            using (System.IO.StreamWriter outputFileCsvGeneric = new System.IO.StreamWriter(@"C:\Users\EXNintern4\Documents\Visual Studio 2015\Projects\AlbumProject\outputCsvGeneric.csv"))
            {
                outputFileCsvGeneric.WriteLine(csvGeneric);
            }
            // Console.WriteLine(csv_artist_generic);
            //Console.ReadLine();

            XML_Repository<Album> xml_album_generic = new XML_Repository<Album>();
            Console.WriteLine("----Generic Load Xml----");
            xml_album_generic.Load(pathXml);
            StringBuilder xmlGeneric = xml_album_generic.Commit();
            using (System.IO.StreamWriter outputFileCsvGeneric = new System.IO.StreamWriter(@"C:\Users\EXNintern4\Documents\Visual Studio 2015\Projects\AlbumProject\outputXmlGeneric.xml"))
            {
                outputFileCsvGeneric.WriteLine(xmlGeneric);
            }
            Console.WriteLine(xmlGeneric);
            //Artist
            //Console.WriteLine("----Generic Load Xml for artist----");
            //csv_artist_generic.Load(pathCsvArtist);
            //StringBuilder csvGenericArtist = csv_artist_generic.Commit();
            //Console.WriteLine(csvGenericArtist);

        }
    }
}
