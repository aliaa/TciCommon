﻿using AliaaCommon;
using AliaaCommon.MongoDB;
using MongoDB.Driver;
using Ninject;
using Ninject.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using TciCommon.Models;

namespace TciCommon
{
    public abstract class BasePage : PageBase
    {
        [Inject]
        public PersianCharacters PersianChars { get; set; }

        [Inject]
        public DataTableFactory TableFactory { get; set; }

        [Inject]
        public MongoHelper DB { get; set; }

        [Inject]
        [Optional]
        public Province Province { get; set; }

        public IEnumerable<City> Cities => DB.Find<City>(c => c.Province == Province.Id).SortBy(c => c.Name).ToEnumerable();

        public bool CompressViewState { get; set; } = false;

        protected override object LoadPageStateFromPersistenceMedium()
        {
            if(CompressViewState)
                return Compressor.DecompressViewState(Request);
            return base.LoadPageStateFromPersistenceMedium();
        }

        protected override void SavePageStateToPersistenceMedium(object state)
        {
            if (CompressViewState)
                Compressor.CompressViewState(ClientScript, state);
            else
                base.SavePageStateToPersistenceMedium(state);
        }

        protected T CreateUserControl<T>() where T : UserControl
        {
            return (T)LoadControl("~/Controls/" + typeof(T).Name + ".ascx");
        }
    }
}
