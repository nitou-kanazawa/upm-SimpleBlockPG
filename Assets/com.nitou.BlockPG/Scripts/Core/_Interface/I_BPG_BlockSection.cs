using UnityEngine;

namespace nitou.BlockPG.Interface{

    public interface I_BPG_BlockSection : ILayoutable {
        
        I_BPG_Block Block { get; }

        I_BPG_BlockSectionHeader Header { get; }

        I_BPG_BlockSectionBody Body { get; }
    }
}
