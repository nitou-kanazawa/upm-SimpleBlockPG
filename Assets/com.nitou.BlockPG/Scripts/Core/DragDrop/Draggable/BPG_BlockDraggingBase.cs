using nitou.BlockPG.Events;
using UnityEngine;
using UnityEngine.EventSystems;

namespace nitou.BlockPG.DragDrop {
    using nitou.BlockPG.Interface;
    using nitou.BlockPG.Block;

    [DisallowMultipleComponent]
    public class BPG_BlockDraggingBase : BPG_ComponentBase, I_BPG_Draggable,
        IPointerDownHandler,IDragHandler, IBeginDragHandler, IEndDragHandler {

        // reference
        protected DraggingSystem _system;

        // misc
        private Vector2 _offset;


        /// ----------------------------------------------------------------------------
        // Property

        /// <summary>
        /// Target block.
        /// </summary>
        public I_BPG_Block Block { get; private set; }

        /// <summary>
        /// Reference point for raycast.
        /// </summary>
        public Vector2 RayPoint => transform.position;

        /// <summary>
        /// 
        /// </summary>
        public bool IsDragging { get; private set; } = false;


        /// ----------------------------------------------------------------------------
        // Lifcyle Events

        private void OnEnable() {
            Block = GetComponent<I_BPG_Block>();
            _system = DraggingSystem.Instance;
            if (Block is null) {
                Debug.LogWarning("Block is not attched.");
                this.enabled = false;
                return;
            }

        }


        /// ----------------------------------------------------------------------------
        #region Event handler

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData) {
            OnPointerDown(eventData);
            BPG_BlockEventBus.PublishTouchEvent(Block);
        }

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData) {
            _offset = RayPoint - eventData.position;

            // 
            if (_system.CanDrag(this)) {
                IsDragging = true;
                OnBegineDrag(eventData);
            }
        }

        void IDragHandler.OnDrag(PointerEventData eventData) {
            if (IsDragging) {
                // apply position
                RectTransform.position = eventData.position + _offset;
                OnDrag(eventData);
            }
        }

        void IEndDragHandler.OnEndDrag(PointerEventData eventData) {
            if (IsDragging) {
                OnEndDrag(eventData);
                IsDragging = false;
            }

            // Hide ghost block
            _system.GhostBlock.Hide();
            _system.GhostBlock.RectTransform.SetParent(null);

            // event
            BPG_InputEventBus.PublishPrimaryKeyUpEnd();
        }
        #endregion


        /// ----------------------------------------------------------------------------
        // Public Method

        public virtual void OnPointerDown(PointerEventData eventData) { }

        public virtual void OnBegineDrag(PointerEventData eventData) {}
        
        public virtual void OnDrag(PointerEventData eventData) { }

        public virtual void OnEndDrag(PointerEventData eventData) { }


        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
        /// 
        /// </summary>
        protected bool DropToRaycastedFreeSpot(PointerEventData eventData) {
            // Doropエリアを取得する
            var spot = _system.GetSpotAtPosition(eventData);
            if (spot is BPG_SpotProgrammingEnv progEnvSpot) {

                // ProgramEnv取得
                var programmingEnv = progEnvSpot.GetProgrammingEnv();
                if (programmingEnv != null) {
                    programmingEnv.Append(this);
                    return true;
                }
            }

            // if can`t find any spot, remove block.
            BPG_BlockUtils.RemoveBlock(Block);
            return false;
        }

        /// <summary>
        /// 位置姿勢を調整する．
        /// </summary>
        protected void AdjustTransformPositionAndRotation() {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
            transform.localEulerAngles = Vector3.zero;
        }
    }
}
