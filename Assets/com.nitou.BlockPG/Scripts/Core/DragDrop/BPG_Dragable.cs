using UnityEngine;
using UnityEngine.EventSystems;

namespace nitou.BlockPG.DragDrop{
    using nitou.BlockPG.Interface;
    using nitou.BlockPG.Events;

    public class BPG_Dragable : MonoBehaviour, I_BPG_Dragable,
        IDragHandler, IBeginDragHandler, IEndDragHandler {

        // references
        private RectTransform _rectTransform;
        private I_BPG_Block _block;

        // 
        private Vector2 _offset;


        /// ----------------------------------------------------------------------------
        // Property

        public RectTransform RectTransform => (_rectTransform != null) ? _rectTransform : (_rectTransform = gameObject.GetComponent<RectTransform>());

        /// <summary>
        /// äÓèÄç¿ïWÅD
        /// </summary>
        public Vector2 RayPoint => RectTransform.position;

        /// <summary>
        /// Target block.
        /// </summary>
        public I_BPG_Block Block => (_block != null) ? _block : (_block = GetComponent<I_BPG_Block>());


        /// ----------------------------------------------------------------------------
        // Interface Method (Trigger events)

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData) {
            BPG_DraggingExecuter.Instance.StartDragging(this, eventData);

            _offset = RayPoint - eventData.position;
            BPG_DraggingExecuter.Instance.AssignToDraggedParent(this);
        }

        void IDragHandler.OnDrag(PointerEventData eventData) {

            // apply position
            RectTransform.position = eventData.position + _offset;
        }

        void IEndDragHandler.OnEndDrag(PointerEventData eventData) {


            RectTransform.SetParent(null);

            BPG_DraggingExecuter.Instance.EndDragging(this, eventData);
        }

        /// ----------------------------------------------------------------------------
        // Protected Method 

        public virtual void OnDrag(PointerEventData eventData) {
            transform.position = eventData.position;
        }

        public virtual void OnBeginDrag(PointerEventData eventData) {

            Debug.Log("Begine");
        }

        public virtual void OnEndDrag(PointerEventData eventData) {
            Debug.Log("End");
        }

    }
}
