using UnityEngine;

namespace nitou.BlockPG.Interface{

    public interface I_BPG_BlockSectionHeaderItem{

        RectTransform RectTransform { get; }
        
        /// <summary>
        /// Item size.
        /// </summary>
        Vector2 Size { get; }
    }
}