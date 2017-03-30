using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumProject
{
    class Artist:BaseEntity
    {
        public string Name
        {
            get; set;
        }
        public Album album
        {
            get;
            set;
        }
        
    }

}
