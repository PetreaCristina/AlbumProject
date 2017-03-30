using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace AlbumProject
{
    class CSV_Repository<T> : Repository<T>where T:BaseEntity,new()
    {
       
        public override StringBuilder Commit()
        {
            StringBuilder text = new StringBuilder("");        
            var properties = Items[0].GetType().GetProperties();
            for (var i = 0; i < properties.Length; i++)
            {
                text.Append(properties[i].Name);
                    if(i!=properties.Length-1)
                    text.Append(",");               
            }
            text.Append("\r\n");
            foreach (var item in Items)
            { 
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
                            text.Append(property.GetValue(item) + ",");
                        }
                        else
                        //if((property.PropertyType==typeof(Album)))
                        //  {
                        //    text.Append(property.GetValue(item)+",");
                        //  }
                        //else
                        {
                           if(property.GetValue(item,null).ToString().Contains(','))
                            {
                               
                                text.Append(property.GetValue(item) + ",");
                               
                            }
                           else
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
            if (File.Exists(path))
            {
               // string readText = File.ReadAllText(path);
                string[] lines =File.ReadAllLines(path);
                string header = lines[0];
                string[] getHeader = header.Split(',');
                int i = 1;
                int number;
                decimal mydecimal;
                DateTime date;
                while (i<lines.Length)
                {
                    T newItem = new T();
                    string[] values = lines[i].Split(',');
                    foreach (var property in newItem.GetType().GetProperties())
                    {
                        for (int j = 0; j < getHeader.Length; j++)
                        {
                            string str = values[j];
                            var type = property.PropertyType.Name;
                            var nume = property.Name.ToLower();
                            var propheader = getHeader[j];
                           
                            if (nume == getHeader[j])
                            {
                                switch (type)
                                {
                                    case "Int32":
                                        Int32.TryParse(values[j], out number);
                                        property.SetValue(newItem, number);
                                        break;
                                    case "String":
                                        property.SetValue(newItem, values[j].Substring(1, values[j].Length - 2));
                                        break;
                                    case "Decimal":
                                        decimal.TryParse(values[j], out mydecimal);
                                        property.SetValue(newItem, mydecimal);
                                        break;
                                    case "DateTime":
                                        DateTime.TryParse(values[j], out date);
                                        property.SetValue(newItem, date);
                                        break;
                                }
                            }   
                        }
                    }
                    Items.Add(newItem);
                    ++i;
                }
            }
          
        }
        //public static List<T> Build(List<Dictionary<String,String>>listOfItems)
        //{
        //    var results = new List<T>();
        //    var makeProduct = new T();
        //    var getType = makeProduct.GetType();
        //    var getProperty = getType.GetProperties();
        //    foreach(var items in listOfItems)
        //    {
        //        makeProduct = new T();
        //        foreach(var dict in items)
        //        {
        //            var key = dict.Key;
        //            var value = dict.Value;
        //            var findProductProperty = getProperty.Where(x => x.Name.ToLowerInvariant() == key.ToLowerInvariant()).FirstOrDefault();
        //            if(findProductProperty!=null)
        //            {
        //                findProductProperty.SetValue(makeProduct, value, null);
        //            }
        //        }
        //        results.Add(makeProduct);
        //    }
        //    return results;
        //}
    }
}
