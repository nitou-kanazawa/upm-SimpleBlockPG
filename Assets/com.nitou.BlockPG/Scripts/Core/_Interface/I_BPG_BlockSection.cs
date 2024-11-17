using UnityEngine;

namespace nitou.BlockPG.Interface{

    public interface I_BPG_BlockSection : ILayoutable {
        
        I_BPG_Block Block { get; }

        I_BPG_BlockSectionHeader Header { get; }

        I_BPG_BlockSectionBody Body { get; }
    }


    /// <summary>
    /// Basic extension methods for type of <see cref="I_BPG_BlockSection"/>.
    /// </summary>
    public static class BPG_BlockSection_Extensions {


        /// ----------------------------------------------------------------------------
        #region Getter

        /// <summary>
        /// Obtains a reference to the parent section to which it belongs.
        /// </summary>
        //public static I_BPG_Block GetParentBlock(this I_BPG_BlockSection self) {
        //    return (self.ParentSection != null) ? self.ParentSection.Block : null;
        //}

        #endregion
    }
}
