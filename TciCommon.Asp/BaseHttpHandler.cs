using AliaaCommon;
using EasyMongoNet;
using Ninject;
using Ninject.Web;

namespace TciCommon.Asp
{
    public abstract class BaseHttpHandler : HttpHandlerBase
    {
        [Inject]
        public IStringNormalizer StringNormalizer { get; set; }

        [Inject]
        public DataTableFactory TableFactory { get; set; }

        [Inject]
        public IDbContext DB { get; set; }

        public override bool IsReusable => true;
    }
}
