using Blog.DataServices.ServiceManagers;
using Blog.Models;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class PostsController : Controller
    {
        private readonly ServiceManager _serviceManager = new ServiceManager();


        [ActionName("last-posts")]
        public ActionResult LastPosts(int count = 15)
        {
            var lastPosts = _serviceManager.Posts.GetLastPosts(count);
            return View("LastPosts", lastPosts);
        }

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