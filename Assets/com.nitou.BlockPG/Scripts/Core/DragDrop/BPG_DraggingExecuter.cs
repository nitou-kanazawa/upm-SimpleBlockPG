using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using nitou.Utils;

// [REF]
//  qiita: UniRxを使ったドラッグ移動のサンプル https://qiita.com/su10/items/ae3fd460a5762438a9d1

namespace nitou.BlockPG.DragDrop{
    using nitou.BlockPG.Interface;


    public sealed class BPG_DraggingExecuter : SingletonMonoBehaviour<BPG_DraggingExecuter> {

        [Header("Dragging")]
        [SerializeField] Transform _draggingObjParent;


        private BPG_Dragable CurrentDrag = null;
        private Vector2 _offset;




        internal void StartDragging(BPG_Dragable dragable, PointerEventData eventData) {
            CurrentDrag = dragable;
            _offset = dragable.RayPoint - eventData.position;
            CurrentDrag.OnBeginDrag(eventData);
        }

        internal void EndDragging(BPG_Dragable dragable, PointerEventData eventData) {
            CurrentDrag = null;
        }



        //private Vector3 GetPosition(PointerEventData eventData) {
        //    var screenPosition = eventData.position;
        //    var result = Vector3.zero;

        //    switch (this.canvas.renderMode) {
        //        case RenderMode.ScreenSpaceOverlay:
        //        case RenderMode.ScreenSpaceCamera:
        //            RectTransformUtility.ScreenPointToWorldPointInRectangle(
        //                this.target,
        //                screenPosition,
        //                eventData.pressEventCamera,
        //                out result);
        //            break;
        //        case RenderMode.WorldSpace:
        //            // TODO: WorldSpaceのCanvas対応
        //            Debug.LogWarning("not supported RenderMode.WorldSpace.");
        //            break;
        //    }

        //    return result;
        //}

        //private void OnDrag(Pair<Vector3> positions) {
        //    var deltaX = this.horizontal ? positions.Current.x - positions.Previous.x : 0;
        //    var deltaY = this.vertical ? positions.Current.y - positions.Previous.y : 0;
        //    this.target.position += new Vector3(deltaX, deltaY, 0);
        //}


        /// <summary>
        /// 指定した<see cref="I_BE2_Drag"/>をDraggedParentの子に設定する
        /// </summary>
        public void AssignToDraggedParent(I_BPG_Dragable dragable) {
            if (dragable.RectTransform.parent == _draggingObjParent)
                return;

            // set parent
            dragable.RectTransform.SetParent(_draggingObjParent, worldPositionStays: true);
        }

    }
}
