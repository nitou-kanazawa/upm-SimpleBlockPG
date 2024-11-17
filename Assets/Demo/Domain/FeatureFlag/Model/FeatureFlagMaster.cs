using System;
using UnityEngine;

namespace Project.Domain.FeatureFlag.Model {

    [Serializable]
    public class FeatureFlagMaster {

        [SerializeField] string id;
        [SerializeField] bool enabled;

        public string Id => id;
        public bool Enabled => enabled;
    }

}