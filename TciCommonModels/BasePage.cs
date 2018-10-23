using AliaaCommon;
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
    public abstract class BasePage : PageBase
    {
        [Inject]
        public PersianCharacters PersianChars { get; set; }

        [Inject]
        public DataTableFactory TableFactory { get; set; }

        [Inject]
        public MongoHelper DB { get; set; }

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
    }
}
