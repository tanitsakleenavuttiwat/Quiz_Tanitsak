using Newtonsoft.Json;
using Quiz_Tanitsak_Ui.Interface;

namespace Quiz_Tanitsak_Ui.Business
{
    public class HelperBC : IHelper
    {
        public T DeserializeObject<T>(string data)
        {
            var deserial = JsonConvert.DeserializeObject<T>(data);
            return deserial;
        }
    }
}
