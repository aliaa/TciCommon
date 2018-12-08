﻿using AliaaCommon;
using AliaaCommon.MongoDB;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using TciCommon.Models;
using MongoDB.Driver;
using Ninject.Planning.Bindings.Resolvers;

namespace TciCommon
{
    public class IOC
    {
        protected string rootPath;
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        public static IKernel kernel;

        public void Start(string rootPath)
        {
            this.rootPath = rootPath;
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private IKernel CreateKernel()
        {
            kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => bootstrapper.Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                kernel.Components.RemoveAll<IMissingBindingResolver>();
                kernel.Components.Add<IMissingBindingResolver, DefaultValueBindingResolver>();
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

        protected virtual void RegisterServices(IKernel kernel)
        {
            kernel.Bind<DataTableFactory>().ToSelf();
            var persianCharacters = new PersianCharacters(rootPath);
            kernel.Bind<PersianCharacters>().ToConstant(persianCharacters);
            
            MongoHelper db = new MongoHelper(persianCharacters, ConfigurationManager.AppSettings["DBName"], ConfigurationManager.AppSettings["MongoConnString"],
                ConfigurationManager.AppSettings["setDictionaryConventionToArrayOfDocuments"] == "true", GetCustomConnections());
            db.DefaultUnifyChars = true;
            kernel.Bind<MongoHelper>().ToConstant(db);

            string provincePrefix = ConfigurationManager.AppSettings["Province"];
            if (provincePrefix != null)
            {
                var province = db.Find<Province>(p => p.Prefix == provincePrefix).FirstOrDefault();
                kernel.Bind<Province>().ToConstant(province);
            }
        }

        protected List<MongoHelper.CustomConnection> GetCustomConnections()
        {
            var customConnections = new List<MongoHelper.CustomConnection>();
            foreach (var key in ConfigurationManager.AppSettings.AllKeys.Where(k => k.StartsWith("MongodbCustomConnection_")))
            {
                string value = ConfigurationManager.AppSettings[key];
                var con = new MongoHelper.CustomConnection
                {
                    DBName = value.Substring(0, value.IndexOf(';')).Trim(),
                    ConnectionString = value.Substring(value.IndexOf(';') + 1).Trim(),
                    Type = key.Substring(key.IndexOf('_') + 1)
                };
                customConnections.Add(con);
            }
            return customConnections;
        }
    }
}