using Cysharp.Threading.Tasks;
using Project.Domain.Shared.MasterRepository;
using Project.Domain.FeatureFlag.Model;

namespace Project.Domain.FeatureFlag.MasterRepository{

    /// <summary>
    /// Master repository of feature flag.
    /// </summary>
    public interface IFeatureFlagMasterRepository : IMasterRepository{

        /// <summary>
        /// 
        /// </summary>
        UniTask<IFeatureFlagMasterTable> FetchTableAsync();
    }

}
