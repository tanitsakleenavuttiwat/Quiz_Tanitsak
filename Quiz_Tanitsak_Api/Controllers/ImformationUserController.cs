using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz_Tanit_API.Models.Entity;
using Quiz_Tanitsak_Api.Helper;
using Quiz_Tanitsak_Api.Interface;
using Quiz_Tanitsak_Api.Models.Entity;
using System.Security.Cryptography.Xml;

namespace Quiz_Tanitsak_Api.Controllers
{
    [Route("api/ImformationUser")]
    [ApiController]
    public class ImformationUserController : ControllerBase
    {
        private readonly ILogger<ImformationUserController> log;
        readonly IConfiguration configuration;
        IImformationUser imformationUser;
        ILoggerInfo loggerInfo;
        public ImformationUserController(ILogger<ImformationUserController> logger, IConfiguration configuration, IImformationUser imformationUser, ILoggerInfo loggerInfo)
        {
            this.log = logger;
            this.configuration = configuration;
            this.imformationUser = imformationUser;
            this.loggerInfo = loggerInfo;
        }


        /// <summary>
        /// GET
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetImformationUserView")]
        public GetImformationUserViewModel GetImformationUserView()
        {
            GetImformationUserViewModel model = new GetImformationUserViewModel();
            try
            {
                model = imformationUser.GetImformationUserViewBC();
            }
            catch (Exception ex)
            {
                model.status = Const.STATUS_ERROR;
                model.message = ex.Message;
                loggerInfo.Info("Fatal Message : " + ex.Message);
                loggerInfo.Info("Exception StackTrace : " + ex.StackTrace);
                if (ex.InnerException != null)
                {
                    loggerInfo.Info("InnerException Message : " + ex.InnerException.Message);
                    loggerInfo.Info("InnerException StackTrace : " + ex.InnerException.StackTrace);
                }
            }

            return model;
        }

        /// <summary>
        /// POST
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateImformationUserView")]
        public UpdateImformationUserViewModel UpdateImformationUserView(UpdateImformationUserViewReq req)
        {
            UpdateImformationUserViewModel model = new UpdateImformationUserViewModel();
            try
            {
                model = imformationUser.UpdateImformationUserViewBC(req);
            }
            catch (Exception ex)
            {
                model.status = Const.STATUS_ERROR;
                model.message = ex.Message;
                loggerInfo.Info("Fatal Message : " + ex.Message);
                loggerInfo.Info("Exception StackTrace : " + ex.StackTrace);
                if (ex.InnerException != null)
                {
                    loggerInfo.Info("InnerException Message : " + ex.InnerException.Message);
                    loggerInfo.Info("InnerException StackTrace : " + ex.InnerException.StackTrace);
                }
            }

            return model;
        }
    }
}
