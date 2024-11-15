using UnityEngine;

namespace nitou.BlockPG.DragDrop{
    using nitou.BlockPG.Interface;

    [DisallowMultipleComponent]
    public abstract class BPG_SpotBase : MonoBehaviour , I_BPG_Spot
    {
        private RectTransform _rectTransform;


        public RectTransform RectTransform => (_rectTransform != null) ? _rectTransform : (_rectTransform = gameObject.GetComponent<RectTransform>());

        public abstract Vector2 DropPosition { get; }


        /// ----------------------------------------------------------------------------
        // Lifecycle Events

        void OnEnable() => BPG_Spot.Register(this);

        void OnDisable() => BPG_Spot.Unregister(this);

    }
}
