using UnityEngine;

namespace nitou.BlockPG.Block.Section {
    using nitou.BlockPG.Interface;

    public sealed class BPG_BlockSectionHeader_Item : BPG_ComponentBase, I_BPG_BlockSectionHeaderItem {

        public Vector2 Size => RectTransform.sizeDelta;

    }
}
