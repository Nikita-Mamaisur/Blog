using Blog.DataServices.Models.Posts;
using Blog.DataServices.ServiceManagers;
using System.Web.ModelBinding;
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
            return View(new PostModel());
        }

        [HttpPost]
        public ActionResult Add(PostModel model)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.Posts.Add(model);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}