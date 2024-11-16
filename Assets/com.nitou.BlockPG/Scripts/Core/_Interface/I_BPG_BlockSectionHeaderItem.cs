using UnityEngine;

namespace nitou.BlockPG.Interface{

    public interface I_BPG_BlockSectionHeaderItem{

        RectTransform RectTransform { get; }
        
        Vector2 Size { get; }
    }
}