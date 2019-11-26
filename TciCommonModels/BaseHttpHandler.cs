using AliaaCommon;
using AliaaCommon.MongoDB;
using Ninject;
using Ninject.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TciCommon
{
    public abstract class BaseHttpHandler : HttpHandlerBase
    {
        [Inject]
        public IStringNormalizer StringNormalizer { get; set; }

        [Inject]
        public DataTableFactory TableFactory { get; set; }

        [Inject]
        public MongoHelper DB { get; set; }

        public override bool IsReusable => true;
    }
}
