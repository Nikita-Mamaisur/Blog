using Blog.DataAccess.Entities;
using Blog.DataServices.Models.Posts;
using Blog.DataServices.ServiceManagers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        private readonly ServiceManager _serviceManager = new ServiceManager();

        public UserManager<User> UserManager
        {
            get => HttpContext.GetOwinContext().GetUserManager<UserManager<User>>();
        }

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
        [ValidateAntiForgeryToken]
        public ActionResult Add(PostModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                _serviceManager.Posts.Add(model, userId);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpPost]
        [ActionName("add-comment")]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(CommentModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                _serviceManager.Posts.AddComment(model, userId);

                returnUrl = !string.IsNullOrEmpty(returnUrl) ? returnUrl : "/";
                return Redirect(returnUrl);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}