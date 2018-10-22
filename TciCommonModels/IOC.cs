using AliaaCommon;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TciCommon
{
    public static class IOC
    {
        private static string rootPath;
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        public static IKernel kernel;

        public static void Start(string rootPath)
        {
            IOC.rootPath = rootPath;
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => bootstrapper.Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        public static T Get<T>()
        {
            return kernel.Get<T>();
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<PersianCharacters>().ToConstant(new PersianCharacters(rootPath));
            kernel.Bind<DataTableFactory>().ToSelf();
        }

    }
}