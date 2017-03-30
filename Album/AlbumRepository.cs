using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumProject
{
    abstract class AlbumRepository
    {
        public List<Album> Albums = new List<Album>();
        public int Add(Album album)
        {
            int lastId = GetLastId();
            album.Id = lastId + 1;
            Albums.Add(album); 
            return album.Id;
        }
       public Album Get(int id)
        {
            foreach (var item in Albums)
            {
                if (item.Id == id)
                    return item;
            }
            throw new Exception("Id not found");
        }
        public int GetLastId()
        {
            int max = 0;
            foreach (var item in Albums)
            {
                if (item.Id>max)
                {
                    max = item.Id;
                }
            }
            return max;
        }
        public List<Album> GetAll()
        {
            return this.Albums;
        }
       public void Update(Album album)
        {
            Delete(album.Id);
            Albums.Add(album);
        }
       public  void Delete(int id)
        {
            Album albumForDelete;
            albumForDelete = Get(id);
            Albums.Remove(albumForDelete);
        }
        public abstract StringBuilder Commit();
        public abstract void Load(string path);
    }
}
