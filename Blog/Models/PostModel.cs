using System.Web.Mvc;

namespace Blog.Models
{
    public class PostModel : DataServices.Models.Posts.PostModel
    {
        [AllowHtml]
        public new string Body
        {
            get => base.Body;
            set => base.Body = value;
        }
    }
}