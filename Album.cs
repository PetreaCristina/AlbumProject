using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumProject
{
    class Album
    {
       public static int id_counter = 0;
       public int id
        {
            get;
            set;
        }
       public string name
        {
            get; set;
        }
       public string artist
        {
            get;set;
        }
       public DateTime releaseDate
        {
            get;set;
        }
       public string description
        {
            get;set;
        }
       public string gen
        {
            get;set;
        }
       public decimal price
        {
            get;set;
        }
        public Album()
        {
            id++;
        }
    }
}
