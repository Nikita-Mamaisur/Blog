using System.Web.Optimization;

namespace Blog
{
    public static class BundleConfig
    {
        public static void Configuration(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/content/lib")
                .Include("~/content/bootstrap.css"));

            bundles.Add(new ScriptBundle("~/scripts/lib")
                .Include("~/scripts/jquery-3.0.0.js")
                .Include("~/scripts/umd/popper.js")
                .Include("~/scripts/bootstrap.js"));
        }
    }
}