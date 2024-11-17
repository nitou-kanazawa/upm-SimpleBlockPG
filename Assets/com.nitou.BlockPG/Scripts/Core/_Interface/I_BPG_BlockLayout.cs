using System.Collections.Generic;
using UnityEngine;

namespace nitou.BlockPG.Interface{

    /// <summary>
    /// 
    /// </summary>
    public interface I_BPG_BlockLayout : ILayoutable{

        /// <summary>
        /// Child sections.
        /// </summary>
        IReadOnlyList<I_BPG_BlockSection> Sections { get; }

        /// <summary>
        /// Block visible color.
        /// </summary>
        Color Color { get; set; }
    }
}
