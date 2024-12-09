using UnityEngine;

namespace nitou.BlockPG.DragDrop {
    using nitou.BlockPG.Interface;

    public sealed class BPG_SpotBlockBody : BPG_Spot{

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

        public static void ConnectTo(this I_BPG_Block block, BPG_SpotBlockBody spotBlockBody) {
            block.RectTransform.SetParent(spotBlockBody.RectTransform);
            block.RectTransform.SetSiblingIndex(0);
        }
    }
}
