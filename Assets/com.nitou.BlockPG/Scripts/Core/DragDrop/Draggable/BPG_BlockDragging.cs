using UnityEngine;
using UnityEngine.EventSystems;

namespace nitou.BlockPG.DragDrop{
    using nitou.BlockPG.Interface;
    using nitou.BlockPG.Events;

    public class BPG_BlockDragging : BPG_BlockDraggingBase {

        /// ----------------------------------------------------------------------------
        // Interface Method

        public override void OnBegineDrag(PointerEventData eventData) {
            // append to dagging layer
             _system.AssignToDraggingPanel(this);
        }

        public override void OnDrag(PointerEventData eventData) { }

        public override void OnEndDrag(PointerEventData eventData) {

            if (DropToRaycastedFreeSpot(eventData)) { 
                AdjustTransformPositionAndRotation();
            }
        }

    }
}
