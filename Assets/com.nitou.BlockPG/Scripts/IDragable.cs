using UnityEngine;
using UnityEngine.EventSystems;

namespace nitou.BlockPG{

    public class IDragable : MonoBehaviour,
        IDragHandler, IBeginDragHandler, IEndDragHandler {


        public void OnBeginDrag(PointerEventData eventData) {
            Debug.Log("Start ---------");
        }

        public void OnDrag(PointerEventData eventData) {
            Debug.Log("On Dragging.");
            transform.position = eventData.position;

        }

        public void OnEndDrag(PointerEventData eventData) {
            Debug.Log("End ---------");
        }
    }
}
