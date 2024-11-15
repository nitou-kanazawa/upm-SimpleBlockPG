using System.Collections.Generic;
using UnityEngine;

namespace nitou.BlockPG.Interface{
    using nitou.BlockPG.Block.Section;

    /// <summary>
    /// 
    /// </summary>
    public interface I_BPG_BlockLayout{

        IReadOnlyList<I_BPG_BlockSection> Sections { get; }

        /// <summary>
        /// Block visible color.
        /// </summary>
        Color Color { get; set; }

        /// <summary>
        /// Returns the size of the whole block. Headers and Bodies with child blocks are counted on.
        /// </summary>
        Vector2 Size { get; }

    }
}
