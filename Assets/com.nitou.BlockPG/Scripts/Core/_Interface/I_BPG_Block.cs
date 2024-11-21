using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using nitou.AssetLoader;

namespace nitou.BlockPG.Interface {

    // [NOTE]
    //  Parent hierarchy info : ParentSection
    //  Self hierarchy info   : Drag, Instruction, Layout
    //  Child hierarchy info  : Layout

    /// <summary>
    /// The interface for block instance. Serves as a façade.
    /// </summary>
    public interface I_BPG_Block {
        
        /// <summary>
        /// RectTransform to contorol position and size of block.
        /// </summary>
        RectTransform RectTransform { get; }

        /// <summary>
        /// Classification of block.
        /// </summary>
        BlockType Type { get; }

        /// <summary>
        /// Parent section. if block is root object, section is null. 
        /// </summary>
        I_BPG_BlockSection ParentSection { get; }

        /// <summary>
        /// 
        /// </summary>
        I_BPG_BlockLayout Layout { get; }

        /// <summary>
        /// Behavior during drag operations.
        /// </summary>
        I_BPG_Draggable Drag { get; }

        /// <summary>
        /// Functional implementation of blocks.
        /// </summary>
        I_BPG_Instruction Instruction { get; }

        /// <summary>
        /// 
        /// </summary>
        void SetParent(I_BPG_BlockSection parentSection);
    }


    /// <summary>
    /// Basic extension methods for type of <see cref="I_BPG_Block"/>.
    /// </summary>
    public static class BPG_Block_Extensions {

        /// ----------------------------------------------------------------------------
        #region Info

        public static bool IsTrigger(this I_BPG_Block self) {
            return self.Type is BlockType.Trigger;
        }

        public static bool IsCondition(this I_BPG_Block self) {
            return self.Type is BlockType.Condition;
        }

        public static int GetGameObjectID(this I_BPG_Block self) {
            return self.RectTransform.gameObject.GetInstanceID();
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
        /// 
        /// </summary>
        public static I_BPG_Block GetRootBlock(this I_BPG_Block self) {
            var parentBlock = self.GetParentBlock();
            return (parentBlock != null) ? parentBlock.GetRootBlock() : self;
        }

        /// <summary>
        /// 子階層以下の<see cref="I_BE2_Block"/>を再帰的に取得する
        /// </summary>
        public static List<I_BPG_Block> GetAllChaildBlocks(this I_BPG_Block self, bool containSelf = true) {
            if (self == null) return null;

            var blockList = new List<I_BPG_Block>();
            if (containSelf) {
                blockList.Add(self);
            }

            // 子階層以下
            var childBlocks = self.Layout.Sections
                .Where(section => section != null)
                .SelectMany(section => section.GetAllChaildBlocks());
            blockList.AddRange(childBlocks);
            return blockList;
        }

        /// <summary>
        /// 子階層以下の<see cref="I_BPG_Block"/>の数を取得する
        /// </summary>
        public static int GetAllChaildBlocksCount(this I_BPG_Block self, bool containSelf = true) {
            if (self == null)
                throw new System.ArgumentNullException(nameof(self));

            // ※自分自信を含めるかどうか
            int additional = (containSelf ? 1 : 0);

            // 
            return additional +
                self.Layout.Sections
                .Where(section => section != null)
                .Select(section => section.GetAllChaildBlocksCount())
                .Sum();
        }

        /// <summary>
        /// Obtains a reference to the parent section to which it belongs.
        /// </summary>
        public static I_BPG_BlockSection GetFirstSection(this I_BPG_Block self) {
            return self.Layout.Sections.FirstOrDefault();
        }

        /// <summary>
        /// １つ目のセクション直下のブロックを取得する
        /// </summary>
        public static IEnumerable<I_BPG_Block> GetFirstSectionBlocks(this I_BPG_Block self) {
            var firstSection = self.GetFirstSection();
            if (firstSection is null)
                return Enumerable.Empty<I_BPG_Block>();

            return firstSection.GetBodyBlocks();
        }

        #endregion


        /// ----------------------------------------------------------------------------
        #region Setter

        /// <summary>
        /// 
        /// </summary>
        public static void UpdateParentSection(this I_BPG_Block self) {
            var parentSection = self.RectTransform.GetComponentInParent<I_BPG_BlockSection>();
            self.SetParent(parentSection);
        }


        #endregion


        /// ----------------------------------------------------------------------------
        #region Connection

        /// <summary>
        /// 
        /// </summary>
        public static bool ConnectTo(this I_BPG_Block self, I_BPG_Block parentBlock, int sectionIndex = 0, int siblinIndex = 0) {
            var sectionArray = parentBlock.Layout.Sections;
            if (sectionArray is null || sectionIndex.IsOutOfRange(sectionArray) || sectionArray[sectionIndex].Body is null) {
                return false;
            }

            // 接続
            var dropSpot = sectionArray[sectionIndex].Body.Spot;
            self.RectTransform.SetParent(dropSpot.RectTransform);
            self.RectTransform.SetSiblingIndex(siblinIndex);
            self.SetParent(sectionArray[sectionIndex]);

            // セクション更新
            sectionArray[sectionIndex].UpdateLayout();
            if (parentBlock.IsTrigger()) {
                //parentBlock.Instruction.InstructionBase.BlocksStack.PopulateStack();
            }

            return true;
        }

        #endregion
    }

}
