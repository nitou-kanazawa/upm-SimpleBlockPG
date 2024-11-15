using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.EventSystems.PointerInputModule;

namespace nitou.BlockPG.Inputs {

    public class InputModule : MonoBehaviour {

        [SerializeField] BaseInput input;

        /// <summary>
        /// Process the current tick for the module.
        /// </summary>
        public void Process() {

            //var result =

        }




        /// <summary>
        /// Return the first valid RaycastResult.
        /// </summary>
        protected static RaycastResult FindFirstRaycast(List<RaycastResult> candidates) {
            for (var i = 0; i < candidates.Count; ++i) {
                if (candidates[i].gameObject == null)
                    continue;

                return candidates[i];
            }
            return new RaycastResult();
        }

    }
}
