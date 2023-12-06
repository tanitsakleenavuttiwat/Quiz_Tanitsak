using Newtonsoft.Json;
using Quiz_Tanitsak_Api.Interface;
using System.Data;
using System.Reflection;

namespace Quiz_Tanitsak_Api.Helper
{
    public class Helper : IHelper
    {
        List<T> IHelper.DataReaderMapToList<T>(IDataReader dr)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }

        T IHelper.DataReaderMapFirst<T>(IDataReader dr)
        {
            T obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
            }
            return obj;
        }


        List<T> IHelper.DataEntityMapToList<T>(List<T> dr)
        {
            List<T> list = new List<T>();
            T obj = default(T);

            obj = Activator.CreateInstance<T>();
            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                if (!object.Equals(dr, DBNull.Value))
                {
                    prop.SetValue(obj, dr, null);
                }
            }
            list.Add(obj);

            return list;
        }
        T IHelper.DeserializeObject<T>(string data)
        {
            var x = JsonConvert.DeserializeObject<T>(data);
            return x;
        }
    }
}
