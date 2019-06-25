using System.Linq;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class ErrorController : Controller
    {
        private static readonly int[] _errors = { 404 };

        public ActionResult Index(int? statusCode)
        {
            if (statusCode.HasValue && _errors.Contains(statusCode.Value))
            {
                Response.StatusCode = statusCode.Value;
                return View("Error_" + statusCode.ToString());
            }

            Response.StatusCode = 500;
            return View("Error_500");
        }
    }
}