using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumProject
{
    abstract class Repository<T>where T:BaseEntity
    {
        public List<T> Items = new List<T>();
        public int Add(T item)
        {
            int lastId = GetLastId();
            item.Id = lastId + 1;
            Items.Add(item); 
            return item.Id;
        }
       public T Get(int id)
        {
            foreach (var item in Items)
            {
                if (item.Id == id)
                    return item;
            }
            throw new Exception("Id not found");
        }
        public int GetLastId()
        {
            int max = 0;
            foreach (var item in Items)
            {
                if (item.Id>max)
                {
                    max = item.Id;
                }
            }
            return max;
        }
        public List<T> GetAll()
        {
            return this.Items;
        }
       public void Update(T album)
        {
            Delete(album.Id);
            Items.Add(album);
        }
       public  void Delete(int id)
        {
            T albumForDelete;
            albumForDelete = Get(id);
            Items.Remove(albumForDelete);
        }
        public abstract StringBuilder Commit();
        public abstract void Load(string path);


    }
}
