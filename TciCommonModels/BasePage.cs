using AliaaCommon;
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
    }
}
