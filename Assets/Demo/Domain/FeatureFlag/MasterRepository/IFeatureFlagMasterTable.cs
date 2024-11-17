using Project.Domain.FeatureFlag.Model;
using Project.Domain.Shared.MasterRepository;

namespace Project.Domain.FeatureFlag.MasterRepository{

    /// <summary>
    /// Master table of feature flag.
    /// </summary>
    public interface IFeatureFlagMasterTable : IMasterTable {

        /// <summary>
        /// 
        /// </summary>
        FeatureFlagMaster FindById(string id);
    }
}
