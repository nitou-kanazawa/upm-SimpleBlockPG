using UnityEngine;

namespace nitou.BlockPG.DragDrop {
    using nitou.BlockPG.Interface;

    public sealed class BPG_SpotOuterArea : BPG_Spot {

        public override Vector2 DropPosition => RectTransform.position;


        private void Awake() {
            GatherComponents();
        }


        /// ----------------------------------------------------------------------------
        // Private Method

        private void GatherComponents() {
            Block = GetComponentInParent<I_BPG_Block>();
        }


        /// ----------------------------------------------------------------------------
#if UNITY_EDITOR
        private void OnValidate() {
            RectTransform.pivot = new Vector2(0f, 1f);
        }
#endif
    }


    public static partial class BPG_Spot_Extensions {

        public static void InsertNextTo(this I_BPG_Block block, BPG_SpotOuterArea spotOuterArea) {
            // place to the same parent as spot block
            var spotBlockParent = spotOuterArea.Block.RectTransform.parent;
            int spotBlockIndex = spotOuterArea.Block.RectTransform.GetSiblingIndex();
            block.RectTransform.SetParent(spotBlockParent);
            block.RectTransform.SetSiblingIndex(spotBlockIndex + 1);
        }
    }
}
