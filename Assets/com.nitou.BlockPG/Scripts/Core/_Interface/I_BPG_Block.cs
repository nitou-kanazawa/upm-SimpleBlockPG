using System.Linq;
using UnityEngine;

namespace nitou.BlockPG.Interface {

    /// <summary>
    /// The interface for block instance. Serves as a façade.
    /// </summary>
    public interface I_BPG_Block {

        /// <summary>
        /// Classification of blocks.
        /// </summary>
        BlockType Type { get; }
        
        RectTransform RectTransform { get; }

        /// <summary>
        /// Behavior during drag operations.
        /// </summary>
        I_BPG_Dragable Drag { get; }

        I_BPG_BlockLayout Layout { get; }

        /// <summary>
        /// 
        /// </summary>
        I_BPG_BlockSection ParentSection { get;}


        void SetParent(I_BPG_BlockSection parentSection);
    }


    /// <summary>
    /// Basic extension methods for type of <see cref="I_BPG_Block"/>.
    /// </summary>
    public static class BPG_Block_Extensions {

        /// ----------------------------------------------------------------------------
        #region Type

        public static bool IsTrigger(this I_BPG_Block self) {
            return self.Type is BlockType.Trigger;
        }

        public static bool IsCondition(this I_BPG_Block self) {
            return self.Type is BlockType.Condition;
        }

        #endregion


        /// ----------------------------------------------------------------------------
        #region Getter

        /// <summary>
        /// Obtains a reference to the parent section to which it belongs.
        /// </summary>
        public static I_BPG_Block GetParentBlock(this I_BPG_Block self) {
            return (self.ParentSection != null) ? self.ParentSection.Block : null;
        }

        /// <summary>
        /// Obtains a reference to the parent section to which it belongs.
        /// </summary>
        public static I_BPG_BlockSection GetFirstSection(this I_BPG_Block self) {
            return self.Layout.Sections.FirstOrDefault();
        }

        #endregion
    }

}
