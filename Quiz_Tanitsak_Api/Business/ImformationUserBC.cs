using Quiz_Tanitsak_Api.Interface;
using Quiz_Tanitsak_Api.Models.Entity;
using System.Data.SqlClient;

namespace Quiz_Tanitsak_Api.Business
{
    public class ImformationUserBC : IImformationUser
    {
        private IHelper helper;
        private readonly IConfiguration configuration;
        private string connectionString;
        public ImformationUserBC(IConfiguration configuration, IHelper helper)
        {
            this.configuration = configuration;
            this.helper = helper;
        }
        public GetImformationUserViewModel GetImformationUserViewBC()
        {
            GetImformationUserViewModel model = new GetImformationUserViewModel();
            model.getImformationUserViewResps = null;
            connectionString = configuration.GetConnectionString(Const.CONNECTION_STRING_DB);
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cm = null;
                string sql = @"
                    SELECT a.UserId
                    ,FullName = CONCAT(a.Firstname,' ',a.LastName)
                    ,Birthday = FORMAT(a.Birthday,'dd/MM/yyyy')
                    ,Age =  CASE WHEN DATEDIFF(year, datediff (year, a.Birthday, getdate()), a.Birthday) > getdate()
                                THEN DATEDIFF(year, a.Birthday, getdate()) - 1
                                ELSE DATEDIFF(year, a.Birthday, getdate())
                           END 
                    FROM [dbo].[TbMImformationUser] a
                    WHERE 1=1
                ";

                cm = new SqlCommand(sql, conn);
                SqlDataReader reader = cm.ExecuteReader();

                if (reader.HasRows)
                {
                    model.getImformationUserViewResps = new List<GetImformationUserViewResp>();
                    model.getImformationUserViewResps = helper.DataReaderMapToList<GetImformationUserViewResp>(reader);
                    model.status = Const.STATUS_SUCCESS;
                }
                else
                {
                    throw new Exception(Const.NOT_FOUND_MSG + "GetImformationUserView");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
    }
}
