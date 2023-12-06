using Quiz_Tanit_API.Models.Entity;
using Quiz_Tanitsak_Api.Models.Entity;

namespace Quiz_Tanitsak_Api.Interface
{
    public interface IImformationUser
    {
        GetImformationUserViewModel GetImformationUserViewBC();
        UpdateImformationUserViewModel UpdateImformationUserViewBC(UpdateImformationUserViewReq req);
    }
}
