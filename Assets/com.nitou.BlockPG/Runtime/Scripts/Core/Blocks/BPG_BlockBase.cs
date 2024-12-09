using System;
using UnityEngine;

namespace nitou.BlockPG.Blocks {
    using nitou.BlockPG.Interface;

    /// <summary>
    /// The base class for block instance. Serves as a façade.
    /// </summary>
    [SelectionBase]
    [DisallowMultipleComponent]
    public abstract class BPG_BlockBase : BPG_ComponentBase, I_BPG_Block {

        /// <summary>
        /// Classification of blocks.
        /// </summary>
        public abstract BlockType Type { get; }

        /// <summary>
        /// 
        /// </summary>
        public I_BPG_BlockSection ParentSection { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public I_BPG_BlockLayout Layout { get; protected set; }

        /// <summary>
        /// Behavior during drag operations.
        /// </summary>
        public I_BPG_Draggable Drag { get; protected set; }

        /// <summary>
        /// Functional implementation of blocks.
        /// </summary>
        public I_BPG_Instruction Instruction { get; protected set; }

        /// <summary>
        /// 識別ID．
        /// </summary>
        public int Id => gameObject.GetInstanceID();


        /// ----------------------------------------------------------------------------
        // Lifecycle Events

        private void LateUpdate() {
            if(this.IsRootBlock()) {
                Layout.UpdateLayout();
            }
        }


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// Set the active state of the Shadow.
        /// </summary>
        public virtual void SetShadowActive(bool isActive) { }

        /// <summary>
        /// 
        /// </summary>
        public void SetParent(I_BPG_BlockSection parentSection) {
            ParentSection = parentSection;
        }


        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
		/// Obtain a reference to a block-related components.
		/// </summary>
		protected void GatherComponents() {
            Layout = gameObject.GetComponent<I_BPG_BlockLayout>();
            Drag = gameObject.GetComponent<I_BPG_Draggable>();
        }

        /// <summary>
        /// Obtains a reference to the parent section to which it belongs.
        /// </summary>
        protected void GatherParentSection() {
            ParentSection = gameObject.GetComponentInParent<I_BPG_BlockSection>();
        }

        protected void AdjustTransform() {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
            transform.localEulerAngles = Vector3.zero;
        }


        /// ----------------------------------------------------------------------------
#if UNITY_EDITOR
        protected virtual void OnValidate() {
            

        }
#endif
    }
}