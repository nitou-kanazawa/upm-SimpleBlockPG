using UnityEngine;

namespace nitou.BlockPG.Blocks{

    public interface IBlockFactory {
        
        bool IsEnabled { get; }

        TBlock Create<TBlock>(TBlock prefab) where TBlock : BPG_BlockBase;
    }
}
