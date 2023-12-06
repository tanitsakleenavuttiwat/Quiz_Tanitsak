using Microsoft.EntityFrameworkCore.Storage;
using Quiz_Tanit_API.Models.Database;
using Quiz_Tanit_API.Models.Entity;
using Quiz_Tanitsak_Api.Interface;
using Quiz_Tanitsak_Api.Models.Entity;
using System.Data.SqlClient;
using System.Globalization;

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
                    ,a.Address
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

        UpdateImformationUserViewModel IImformationUser.UpdateImformationUserViewBC(UpdateImformationUserViewReq req)
        {
            UpdateImformationUserViewModel model = new UpdateImformationUserViewModel();
            try
            {
                if (req.firstName == null) throw new Exception(Const.INVALID_PARAM_MSG + "firstName");
                if (req.lastName == null) throw new Exception(Const.INVALID_PARAM_MSG + "lastName");
                if (req.birthday == null) throw new Exception(Const.INVALID_PARAM_MSG + "birthday");
                if (req.address == null) throw new Exception(Const.INVALID_PARAM_MSG + "address");

                using (var _db = new DBQuizTanitsakContext())
                {
                    using (IDbContextTransaction transaction = _db.Database.BeginTransaction())
                    {
                        try
                        {
                            TbMimformationUser tbMimformationUser = _db.TbMimformationUsers.Where(x => x.Firstname.Contains(req.firstName) && x.LastName.Contains(req.lastName) && x.IsActive == true).FirstOrDefault();

                            if (tbMimformationUser != null) throw new Exception(Const.DETECH_DATA);

                            if(tbMimformationUser == null)
                            {
                                DateTime dSurveyDate = DateTime.ParseExact(req.birthday, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                                tbMimformationUser = new TbMimformationUser();
                                tbMimformationUser.Firstname = req.firstName;
                                tbMimformationUser.LastName = req.lastName;
                                tbMimformationUser.Birthday = dSurveyDate;
                                tbMimformationUser.Address = req.address;
                                tbMimformationUser.IsActive = true;
                                tbMimformationUser.CreatedBy = 1;
                                tbMimformationUser.CreateDate = DateTime.Now;

                                _db.TbMimformationUsers.Add(tbMimformationUser);
                                _db.SaveChanges();
                            }

                            transaction.Commit();
                            model.status = Const.STATUS_SUCCESS;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }
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
