using System.Data;

namespace Quiz_Tanitsak_Api.Interface
{
    public interface IHelper
    {
        List<T> DataReaderMapToList<T>(IDataReader dr);
        T DataReaderMapFirst<T>(IDataReader dr);
        List<T> DataEntityMapToList<T>(List<T> dr);
        T DeserializeObject<T>(string data);
    }
}
