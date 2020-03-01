using AliaaCommon;
using EasyMongoNet;
using Ninject;
using Ninject.Web;

namespace TciCommon
{
    public abstract class BaseMasterPage : MasterPageBase
    {
        [Inject]
        public IStringNormalizer StringNormalizer { get; set; }

        [Inject]
        public DataTableFactory TableFactory { get; set; }

        [Inject]
        public IDbContext DB { get; set; }
    }
}
