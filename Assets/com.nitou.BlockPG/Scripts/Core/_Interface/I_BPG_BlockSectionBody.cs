using System.Collections.Generic;
using UnityEngine;

namespace nitou.BlockPG.Interface{

    public interface I_BPG_BlockSectionBody : ILayoutable {
        
        IReadOnlyList<I_BPG_Block> ChildBlocks { get; }
        
        I_BPG_BlockSection BlockSection { get; }
        
        I_BPG_Spot Spot { get;}

        /// <summary>
        /// Updates ChildBlocksCount and ChildBlocksArray with the current child blocks.
        /// </summary>
        void UpdateChildBlocks();
    }


    public static class BPG_BlockSectionBody_Extensions {

        public static void Append(this I_BPG_BlockSectionBody self, I_BPG_Block block) {
            block.RectTransform.SetParent(self.RectTransform);
        }

    }

}