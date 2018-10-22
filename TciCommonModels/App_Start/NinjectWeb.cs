[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TciCommon.NinjectWeb), "Start")]

namespace TciCommon
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject.Web.Common;

    public static class NinjectWeb 
    {
        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
        }
    }
}
