using Blog.DataAccess.Context;
using Blog.DataServices.Services;

namespace Blog.DataServices.ServiceManagers
{
    public class ServiceManager
    {
        public PostsService Posts { get; }


        public ServiceManager()
        {
            var context = new BlogContext();
            Posts = new PostsService(context);
        }
    }
}