using Blog.DataServices.Models.Posts;
using Blog.DataServices.ServiceManagers;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class PostsController : Controller
    {
        private readonly ServiceManager _serviceManager = new ServiceManager();

        public ActionResult Show(string slug)
        {
            var model = _serviceManager.Posts.FindBySlug(slug);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(PostModel model)
        {
            _serviceManager.Posts.Add(model);
            return RedirectToAction("Index", "Home");
        }
    }
}