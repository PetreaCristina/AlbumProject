using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumProject
{
    abstract class ArtistRepository
    {
        public List<Artist> Artists = new List<Artist>();
        public int Add(Artist artist)
        {
            int lastId = GetLastId();
            artist.Id = lastId + 1;
            Artists.Add(artist); 
            return artist.Id;
        }
       public Artist Get(int id)
        {
            foreach (var item in Artists)
            {
                if (item.Id == id)
                    return item;
            }
            throw new Exception("Id not found");
        }
        public int GetLastId()
        {
            int max = 0;
            foreach (var item in Artists)
            {
                if (item.Id>max)
                {
                    max = item.Id;
                }
            }
            return max;
        }
        public List<Artist> GetAll()
        {
            return this.Artists;
        }
       public void Update(Artist artist)
        {
            Delete(artist.Id);
            Artists.Add(artist);
        }
       public  void Delete(int id)
        {
            Artist artistForDelete;
            artistForDelete = Get(id);
            Artists.Remove(artistForDelete);
        }
        public abstract StringBuilder Commit();
        public abstract void Load(string path);
    }
}
