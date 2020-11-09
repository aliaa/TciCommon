using AliaaCommon;
using EasyMongoNet;
using MongoDB.Driver;
using Ninject;
using Ninject.Web;
using System;
using System.Collections.Generic;
using System.Web.UI;
using TciCommon.Models;

namespace TciCommon.Asp
{
    public abstract class BaseUserControl : UserControlBase
    {
        [Inject]
        public IStringNormalizer StringNormalizer { get; set; }

        [Inject]
        public DataTableFactory TableFactory { get; set; }

        [Inject]
        public IDbContext DB { get; set; }

        [Inject]
        [Optional]
        public Province Province { get; set; }

        public IEnumerable<City> Cities => DB.Find<City>(c => c.Province == Province.Id).SortBy(c => c.Name).ToEnumerable();

        protected virtual void Page_Init(object sender, EventArgs e)
        {
            RequestActivation();
        }

        protected T CreateUserControl<T>() where T : UserControl
        {
            return (T)LoadControl("~/Controls/" + typeof(T).Name + ".ascx");
        }
    }
}
