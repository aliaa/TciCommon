﻿using AliaaCommon;
using AliaaCommon.Models;
using EasyMongoNet;
using MongoDB.Driver;
using Ninject;
using Ninject.Web;
using System;
using System.Collections.Generic;
using System.Web.UI;
using TciCommon.Models;
using TciCommon.Server;

namespace TciCommon.Asp
{
    public abstract class BasePage : PageBase
    {
        [Inject]
        public IStringNormalizer StringNormalizer { get; set; }

        [Inject]
        public DataTableFactory TableFactory { get; set; }

        [Inject]
        public IDbContext DB { get; set; }

        [Inject][Optional]
        public Province Province { get; set; }

        public IEnumerable<City> Cities => DB.Find<City>(c => c.Province == Province.Id).SortBy(c => c.Name).ToEnumerable();

        public bool CompressViewState { get; set; } = false;

        private AuthUser _currentUser = null;
        public virtual AuthUser CurrentUser
        {
            get
            {
                if (_currentUser == null)
                    _currentUser = DB.GetCurrentUser();
                return _currentUser;
            }
        }

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
