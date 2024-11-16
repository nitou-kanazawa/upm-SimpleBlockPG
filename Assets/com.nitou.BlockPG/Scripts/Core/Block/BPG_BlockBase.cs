using System;
using UnityEngine;

namespace nitou.BlockPG.Block{
    using nitou.BlockPG.Interface;

    /// <summary>
    /// The base class for block instance. Serves as a façade.
    /// </summary>
    [SelectionBase]
    [DisallowMultipleComponent]
    public abstract class BPG_BlockBase : BPG_ComponentBase, I_BPG_Block
    {
        /// <summary>
        /// Classification of blocks.
        /// </summary>
        public abstract BlockType Type { get;}

        /// <summary>
        /// Behavior during drag operations.
        /// </summary>
        public I_BPG_Dragable Drag { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public I_BPG_BlockLayout Layout { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public I_BPG_BlockSection ParentSection { get; protected set; }

        /// <summary>
        /// Idintification id.
        /// </summary>
        public int Id => gameObject.GetInstanceID();


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// Set the active state of the Shadow.
        /// </summary>
        public virtual void SetShadowActive(bool isActive) { }

        public void SetParent(I_BPG_BlockSection parentSection) {
            ParentSection = parentSection;
        }


        /// ----------------------------------------------------------------------------
        // Private Method

        /// <summary>
		/// Obtain a reference to a block-related components.
		/// </summary>
		protected void GatherComponents()
        {
            Layout = gameObject.GetComponent<I_BPG_BlockLayout>();
            Drag = gameObject.GetComponent<I_BPG_Dragable>();
        }

    }

}