using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumProject
{
    abstract class AlbumRepository
    {
        protected List<Album> Albums;
        public int Add(Album album)
        {

            Albums.Add(album);
            return album.id;
        }
       public Album Get(int id)
        {
            foreach (var item in Albums)
            {
                if (item.id == id)
                    return item;
            }
            throw new Exception("Id not found");
        }
        List<Album> GetAll()
        {
            return this.Albums;
        }
        void Update(Album album)
        {
            foreach (var item in Albums)
            {
                if(item.id==album.id)
                {
                    item.name = album.name;
                    item.artist = album.artist;
                    item.price = album.price;
                    item.releaseDate = album.releaseDate;
                    item.description = album.description;
                    item.gen = album.gen;
                }
            }
        }
    }
}
