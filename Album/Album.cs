using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumProject
{
    class Album:BaseEntity
    {
       public string Name
        {
            get; set;
        }
       public string Artist
        {
            get;set;
        }
       public DateTime ReleaseDate
        {
            get;set;
        }
       public string Description
        {
            get;set;
        }
        public int NoSongs
        {
            get;
            set;
        }
       public string Gen
        {
            get;set;
        }
       public decimal Price
        {
            get;set;
        }
        public Album()
        {
            Id++;
        }
        public  Album(string name, DateTime ReleaseDate, string artist="",  int noSongs=0, string description="",string gen="",decimal price=0)
        {
            //this.id = id;
            this.Name = name;
            this.Artist = artist;
            this.ReleaseDate = ReleaseDate;
            this.NoSongs = noSongs;
            this.Description = description;
            this.Gen = gen;
            this.Price = price;
        }
    }
}
