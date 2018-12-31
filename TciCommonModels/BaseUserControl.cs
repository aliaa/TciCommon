﻿using AliaaCommon;
using AliaaCommon.MongoDB;
using Ninject;
using Ninject.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace TciCommon
{
    public abstract class BaseUserControl : UserControlBase
    {
        [Inject]
        public PersianCharacters PersianChars { get; set; }

        [Inject]
        public DataTableFactory TableFactory { get; set; }

        [Inject]
        public MongoHelper DB { get; set; }

        protected virtual void Page_Init(object sender, EventArgs e)
        {
            RequestActivation();
        }

        protected T CreateUserControl<T>() where T : UserControl
        {
            return (T)LoadControl("~/Controls" + typeof(T).Name + ".ascx");
        }
    }
}
