using UnityEngine;
using UnityEngine.UI;
    using System.Collections.Generic;

namespace nitou.BlockPG.Block.Section{
    using nitou.BlockPG.Interface;
    using nitou.BlockPG.DragDrop;
    using System.Linq;

    [DisallowMultipleComponent]
    public class BPG_BlockSectionBody : BPG_ComponentBase , I_BPG_BlockSectionBody{

        private Image _image;
        private BPG_SpotBlockBody _spot;

        private I_BPG_BlockSection _section;
        private I_BPG_BlockLayout _blockLayout;

        // references (children)
        private readonly List<I_BPG_Block> _childBlocks = new();


        private static float HEIGHT_SPCING = 10;


        /// ----------------------------------------------------------------------------
        // Property

        public Vector2 Size {
            get => RectTransform.sizeDelta;
            set => RectTransform.sizeDelta = value;
        }

        public IReadOnlyList<I_BPG_Block> ChildBlocks => _childBlocks;

        public I_BPG_BlockSection BlockSection => _section;

        public I_BPG_Spot Spot => _spot;


        /// ----------------------------------------------------------------------------
        // Lifecycle Events

        void Awake() {
            GatherComponents();

            if (_image != null) {
                _image.type = Image.Type.Sliced;
                _image.pixelsPerUnitMultiplier = 2;
            }
        }


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// Updates the layout of an indivisual block section. Used to correctly resize the section after adding child and operation blocks
        /// </summary>
        public void UpdateLayout() {
            ApplyColor();
            UpdateChildBlocks();
            UpdateSelfSize();
        }

        /// <summary>
        /// Updates ChildBlocksCount and ChildBlocksArray with the current child blocks.
        /// </summary>
        public void UpdateChildBlocks() {
            _childBlocks.Clear();
            foreach (Transform chiled in transform) {
                if (chiled.TryGetComponent<I_BPG_Block>(out var block)) {
                    _childBlocks.Add(block);
                }
            }
        }


        /// ----------------------------------------------------------------------------
        // Private Method

        private void GatherComponents() {

            _image = GetComponent<Image>();
            _spot = GetComponent<BPG_SpotBlockBody>();

            // parents
            if (transform.parent != null) {
                _section = transform.parent.GetComponent<I_BPG_BlockSection>();
                _blockLayout = transform.parent.parent.GetComponent<I_BPG_BlockLayout>();
            }
        }

        private void ApplyColor() {
            if (_image != null && _image.sprite != null && _blockLayout != null) {
                _image.color = _blockLayout.Color;
            }
        }

        private void UpdateSelfSize() {

            float minHeight = _section.Block.IsTrigger() ? 0f : 50f;
            float height = _childBlocks.Sum(child => child.Layout.Size.y - 10) - 10;
            
            height = Mathf.Max(minHeight, height);


            // ì¡íËèåèâ∫Ç≈çÇÇ≥Çâ¡éZ
            bool isSecondLastSibling =
                _section.RectTransform.GetSiblingIndex() == _section.RectTransform.parent.childCount - 2;

            if (isSecondLastSibling && !_section.Block.IsTrigger()) {
                height += 50;
            }

            // apply
            RectTransform.sizeDelta = new Vector2(_section.Size.x, height);
        }


        /// ----------------------------------------------------------------------------
#if UNITY_EDITOR
        private void OnValidate() {
            GatherComponents();
        }
#endif
    }
}
