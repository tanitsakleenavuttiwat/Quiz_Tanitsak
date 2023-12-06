using Microsoft.Extensions.PlatformAbstractions;
using System.Reflection;

namespace Quiz_Tanitsak_Api
{
    public static class XmlCommentsFilePath
    {
        public static string XmlCommentsFilePathx
        {
            get
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = typeof(Program).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }
    }
}
