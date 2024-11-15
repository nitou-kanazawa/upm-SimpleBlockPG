using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace nitou.BlockPG.Inputs {

    public interface IInputHandler {
        void OnUpdate();
    }

    /// <summary>
    /// 
    /// </summary>
    public sealed partial class BPG_InputManager{

        private IInputHandler _handler;

        // references
        private I_BPG_Config _config;

        // 内部処理用
        private float _holdTime = 0;
        private Vector2 _lastPosition;

        private readonly float DRAG_THRESHOLD = 0.5f;


        /// <summary>
        /// Enabled or not.
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Dragging or not.
        /// </summary>
        public bool IsDragging { get; private set; } = false;

        /// <summary>
        /// Screen position of pointer.
        /// </summary>
        public Vector3 ScreenPointerPosition => Input.mousePosition;

        /// <summary>
        /// ポインターのキャンバス座標（※CanvasMode == overlayではスクリーン座標と同値）
        /// </summary>
        public Vector3 CanvasPointerPosition => GetCanvasPointerPosition();


        /// ----------------------------------------------------------------------------
        // LifeCycle Events

        /// <summary>
        /// Constructor.
        /// </summary>
        public BPG_InputManager(I_BPG_Config config) {
            _config = config ?? throw new System.ArgumentNullException(nameof(config));

#if UNITY_IOS || UNITY_ANDROID
            _handler = new TouchInputHandler(this);
#elif UNITY_EDITOR || UNITY_STANDALONE
            _handler = new KeyboardInputHandler(this);
#endif


        }

        public void OnUpdate() {
            if (!IsEnabled)
                return;

            _handler?.OnUpdate();
        }


        /// ----------------------------------------------------------------------------
        // Private Method

        private Vector3 GetCanvasPointerPosition() {
            //switch (_inspector.CanvasRenderMode) {
            //    case RenderMode.ScreenSpaceOverlay:
            //        return ScreenPointerPosition;

            //    case RenderMode.ScreenSpaceCamera:
            //    case RenderMode.WorldSpace:
            //        var screenPoint = ScreenPointerPosition;
            //        screenPoint.z = BE2_DragDropManager.DragDropComponentsCanvas.transform.position.z - _inspector.Camera.transform.position.z; // カメラから平面までの距離
            //        return GetMouseInCanvas(screenPoint);

            //    default:
            //        return Vector3.zero;
            //}

            return Vector3.zero;
        }

        private Vector3 GetMouseInCanvas(Vector3 screenPosition) {
            //RectTransformUtility.ScreenPointToWorldPointInRectangle(
            //    BE2_DragDropManager.DragDropComponentsCanvas.transform as RectTransform,
            //    screenPosition,
            //    _inspector.Camera,
            //    out Vector3 mousePosition
            //);
            //return mousePosition;

            return Vector3.zero;
        }


        /// ----------------------------------------------------------------------------

        // ドラッグ対象か否かを判定するメソッドを追加
        private bool IsDragTarget(GameObject target) {
            // ここに、ドラッグ対象であるかどうかの判定ロジックを実装
            // 例えば、特定のタグやコンポーネントの存在を確認するなど
            return target.CompareTag("Draggable");
        }

        // オーバーラップ判定を追加
        private bool IsPointerOverUI() {
            // 現在のポインター位置にあるUI要素を取得
            var pointerData = new PointerEventData(EventSystem.current) {
                position = ScreenPointerPosition
            };

            // UI要素を格納するリスト
            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            // 結果が空でない場合、何らかのUI要素がある
            return results.Count > 0;
        }
    }


}

