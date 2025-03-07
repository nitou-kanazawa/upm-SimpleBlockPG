using UniRx;
using UnityEngine;

namespace nitou.BlockPG.Blocks{
    using nitou.BlockPG.Events;

    public sealed class BPG_Block : BPG_BlockBase {

        [SerializeField] BlockType _type;

        /// <summary>
        /// Classification of blocks.
        /// </summary>
        public override BlockType Type => _type;


        /// ----------------------------------------------------------------------------
        // Lifecycle Events

        protected override void OnInitialize() {
            GatherComponents();

            // [NOTE] block which parent section is null was can not connectable.
            //BPG_InputEventBus.OnPrimaryKeyUpEnd.Subscribe(_ => GatherParentSection()).AddTo(this);
        }

    }
}
