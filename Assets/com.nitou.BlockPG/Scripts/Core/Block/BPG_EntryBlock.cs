using UniRx;
using UnityEngine;

namespace nitou.BlockPG.Block {
    using nitou.BlockPG.Events;

    /// <summary>
    /// A block instance that serves as the entry point for the program.
    /// </summary>
    public sealed class BPG_EntryBlock : BPG_BlockBase {

        /// <summary>
        /// Classification of blocks.
        /// </summary>
        public override BlockType Type => BlockType.Trigger;


        /// ----------------------------------------------------------------------------
        // Lifecycle Events

        private void Awake() {
            GatherComponents();
        }


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// Set the active state of the Shadow.
        /// </summary>
        public override void SetShadowActive(bool isActive) { }
        //=>  this.SetShadow(isActive);

    }

}