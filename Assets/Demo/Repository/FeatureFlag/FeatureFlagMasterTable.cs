using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Project.Domain.FeatureFlag.Model;
using Project.Domain.FeatureFlag.MasterRepository;

namespace Project.MasterRepository.FeatureFlag {

    [Serializable]
    public sealed class FeatureFlagMasterTable : IFeatureFlagMasterTable {

        [SerializeField] List<FeatureFlagMaster> items = new();

        [NonSerialized] private bool _isInitialized;

        private Dictionary<string, FeatureFlagMaster> _items;


        /// <summary>
        /// Initialize table.
        /// </summary>
        public void Initialize() {
            if (_isInitialized)
                return;

            _items = items.ToDictionary(x => x.Id);

            _isInitialized = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public FeatureFlagMaster FindById(string id) {
            if (!_isInitialized) {
                throw new InvalidOperationException($"{nameof(FeatureFlagMasterTable)} is not initialized. Call {nameof(Initialize)}() first.");
            }

            return !_items.TryGetValue(id, out var item) ? null : item;
        }
    }
}
