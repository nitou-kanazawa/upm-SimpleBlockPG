using Cysharp.Threading.Tasks;
using Project.Domain.FeatureFlag.MasterRepository;
using UnityEngine;

namespace Project.MasterRepository.FeatureFlag {

    public sealed class FeatureFlagMasterRepository : IFeatureFlagMasterRepository {

        private IFeatureFlagMasterTable _table;

        /// <summary>
        /// 
        /// </summary>
        public async UniTask<IFeatureFlagMasterTable> FetchTableAsync() {
            if (_table != null)
                return _table;

            // load table
            var asset = await Resources.LoadAsync<FeatureFlagMasterTableAsset>("FeatureFlagMasterTableAsset") as FeatureFlagMasterTableAsset;
            _table = asset.MasterTable;
            _table.Initialize();

            return _table;
        }

        /// <summary>
        /// 
        /// </summary>
        public void ClearCache() {
            _table = null;
        }
    }
}
