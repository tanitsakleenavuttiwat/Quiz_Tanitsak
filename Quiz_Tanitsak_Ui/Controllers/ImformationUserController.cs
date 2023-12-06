using Microsoft.AspNetCore.Mvc;
using Quiz_Tanitsak_Ui.Interface;
using Quiz_Tanitsak_Ui.Models;
using System.Diagnostics;

namespace Quiz_Tanitsak_Ui.Controllers
{
    public class ImformationUserController : Controller
    {
        private readonly ILogger<ImformationUserController> _logger;
        private static HttpClient client = new HttpClient();
        readonly IConfiguration _configuration;
        IHelper _helper;

        public ImformationUserController(ILogger<ImformationUserController> logger, IConfiguration configuration, IHelper helper)
        {
            _logger = logger;
            _configuration = configuration;
            _helper = helper;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
