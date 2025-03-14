using System;
using UniRx;
using UnityEngine;

namespace nitou.BlockPG.Events{
    using nitou.BlockPG.Interface;
    using nitou.BlockPG.DragDrop;

    /// <summary>
    /// Event bus for within block programming modules.
    /// </summary>
    public static class BPG_BlockEventBus
    {
        // creation and destruction events
        private static Subject<I_BPG_Block> _onCreatedSubject = new();
        private static Subject<I_BPG_Block> _onDestoryedSubject = new();

        // selection and editing events
        private static Subject<I_BPG_Block> _onTouchedSubject = new();
        private static Subject<I_BPG_Block> _onFocusedSubject = new();
        private static Subject<BlockSelectEvent> _onSelectedSubject = new();
        private static Subject<I_BPG_Block> _onEditSubject = new();

        // movement events
        private static Subject<BlockLocationEvent> _onStartDragSubject = new();
        private static Subject<BlockLocationEvent> _onEndDragSubject = new();
        private static Subject<BlockMoveEvent> _onMoveSubject = new();

        // misc
        private static readonly bool debugMode = false;
        private static BlockLocation fromAreaCash = BlockLocation.Outside;


        /// ----------------------------------------------------------------------------
        // Property

        /// <summary>
        /// Observable to notify immediately after a block is created.
        /// </summary>
        public static IObservable<I_BPG_Block> OnCreated => _onCreatedSubject;

        /// <summary>
        /// Observable to notify just before a block is destroyed.
        /// </summary>
        public static IObservable<I_BPG_Block> OnDestroyed => _onDestoryedSubject;

        /// <summary>
        /// Observable to notify when a block is touched.
        /// </summary>
        public static IObservable<I_BPG_Block> OnTouched => _onTouchedSubject;

        /// <summary>
        /// Observable to notify when a block is selected.
        /// </summary>
        public static IObservable<BlockSelectEvent> OnSelected => _onSelectedSubject;

        /// <summary>
        /// Observable to notify when a block is edited.
        /// </summary>
        public static IObservable<I_BPG_Block> OnEdit => _onEditSubject;

        /// <summary>
        /// Observable to notify when block dragging starts.
        /// </summary>
        public static IObservable<BlockLocationEvent> OnStartDrag => _onStartDragSubject;

        /// <summary>
        /// Observable to notify when block dragging ends.
        /// </summary>
        public static IObservable<BlockLocationEvent> OnEndDrag => _onEndDragSubject;

        /// <summary>
        /// Observable to notify when a block is moved.
        /// </summary>
        public static IObservable<BlockMoveEvent> OnMove => _onMoveSubject;


        /// ----------------------------------------------------------------------------
        // Public Method

        static BPG_BlockEventBus()
        {
            if (debugMode)
            {
                // イベント実行時にログ出力
                _onCreatedSubject.Subscribe(block => Debug.Log($"[Create Block] {block}"));
                _onDestoryedSubject.Subscribe(block => Debug.Log($"[Destroy Block]: {block}"));
                _onTouchedSubject.Subscribe(block => Debug.Log($"[Touch Block]: {block}"));
                _onFocusedSubject.Subscribe(block => Debug.Log($"[Focus Block]: {block}"));
                _onSelectedSubject.Subscribe(blockSelectEvent => Debug.Log(blockSelectEvent));
                _onEditSubject.Subscribe(block => Debug.Log($"[Edit Block]: {block}"));
                _onMoveSubject.Subscribe(block => Debug.Log($"[Move Block]: {block}"));
            }
        }


        /// ----------------------------------------------------------------------------
        // Internal Method (イベント発行)

        /// <summary>
        /// ブロックの生成イベント．
        /// </summary>
        internal static void PublishCreateEvent(I_BPG_Block block)
        {
            if (block is null)
            {
                Debug.LogWarning($"{block} is null.");
                return;
            }
            _onCreatedSubject.OnNext(block);
        }

        /// <summary>
        /// ブロックの破棄イベント．
        /// </summary>
        internal static void PublishDestroyEvent(I_BPG_Block block)
        {
            if (block is null)
            {
                Debug.LogWarning($"{block} is null.");
                return;
            }
            _onDestoryedSubject.OnNext(block);
        }

        // -----

        /// <summary>
        /// ブロックのタッチイベント．
        /// </summary>
        internal static void PublishTouchEvent(I_BPG_Block block)
        {
            if (block is null)
            {
                Debug.LogWarning($"{block} is null.");
                return;
            }
            _onTouchedSubject.OnNext(block);
        }

        /// <summary>
        /// ブロックのフォーカスイベント．
        /// </summary>
        internal static void PublishFocusEvent(I_BPG_Block block)
        {
            if (block is null)
            {
                Debug.LogWarning($"{block} is null.");
                return;
            }
            _onFocusedSubject.OnNext(block);
        }

        /// <summary>
        /// ブロックの選択イベント．
        /// </summary>
        internal static void PublishSelectEvent(I_BPG_Block block)
        {
            if (block is null)
            {
                Debug.LogWarning($"{block} is null.");
                return;
            }
            _onSelectedSubject.OnNext(new BlockSelectEvent(block));
        }

        /// <summary>
        /// ブロックの編集イベント．
        /// </summary>
        internal static void PublishEditEvent(I_BPG_Block block)
        {
            if (block is null)
            {
                Debug.LogWarning($"{block} is null.");
                return;
            }
            _onEditSubject.OnNext(block);
        }

        // -----

        /// <summary>
        /// ブロックのドラッグ開始イベント．
        /// </summary>
        internal static void PublishStartDragEvent(I_BPG_Block block, BlockLocation location)
        {
            // ドラッグ開始イベントは"Block == null"も許容
            // ※このイベントを受けてインスタンスが生成される
            _onStartDragSubject.OnNext(new BlockLocationEvent(block, location));

            // cash
            fromAreaCash = location;
        }

        /// <summary>
        /// ブロックのドラッグ終了イベント．
        /// </summary>
        internal static void PublishEndDragEvent(I_BPG_Block block, BlockLocation location)
        {
            _onEndDragSubject.OnNext(new BlockLocationEvent(block, location));
            _onMoveSubject.OnNext(new BlockMoveEvent( block, fromAreaCash, location));
        }

    }

}