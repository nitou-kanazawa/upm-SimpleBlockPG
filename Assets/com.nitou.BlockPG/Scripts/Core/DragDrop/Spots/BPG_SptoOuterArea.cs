using UnityEngine;

namespace nitou.BlockPG.DragDrop {
    using nitou.BlockPG.Interface;

    public sealed class BPG_SptoOuterArea : BPG_SpotBase {

        public override Vector2 DropPosition => RectTransform.position; 
    }
}
