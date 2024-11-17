using UnityEngine;

namespace Project.MasterRepository.FeatureFlag {

    [CreateAssetMenu(menuName = "Project/Master Data/Feature Flag")]
    public sealed class FeatureFlagMasterTableAsset : ScriptableObject{
        
        [SerializeField] FeatureFlagMasterTable masterTable = new ();

        /// <summary>
        /// Master table.
        /// </summary>
        public FeatureFlagMasterTable MasterTable => masterTable;
    }
}
