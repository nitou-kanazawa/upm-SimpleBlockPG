using UnityEngine;

namespace nitou.BlockPG.Block{

    /// <summary>
    /// 
    /// </summary>
    public class BPG_GhostBlock : BPG_ComponentBase{

        /// <summary>
        /// ï\é¶èÛë‘Ç…Ç∑ÇÈ
        /// </summary>
        public void Show(Transform parent, Vector3 localScale, int siblingIndex = 0) {
            transform.SetParent(parent);
            transform.SetSiblingIndex(siblingIndex);
            transform.localScale = localScale;
            AdjustTransform();

            gameObject.SetActive(true);
        }

        /// <summary>
        /// îÒï\é¶èÛë‘Ç…Ç∑ÇÈ
        /// </summary>
        public void Hide() {
            AdjustTransform();

            gameObject.SetActive(false);
        }


        /// ----------------------------------------------------------------------------
        // Private Method

        private void AdjustTransform() {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
            transform.localEulerAngles = Vector3.zero;
        }
    }
}
