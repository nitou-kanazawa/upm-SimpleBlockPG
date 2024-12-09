using System;
using Cysharp.Threading.Tasks;
using Object = UnityEngine.Object;

namespace nitou.AssetLoader {

    public enum AssetLoadStatus {
        None,
        Success,
        Failed,
    }


    public abstract class AssetLoadHandle {

        public int ControlId { get; }

        public AssetLoadStatus Status { get; protected set; }

        public Exception OperationExeption { get; protected set; }

        public bool IsDone => Status is not AssetLoadStatus.None;
        
        protected Func<float> PercentCompleteFunc;


        /// <summary>
        /// Constructor.
        /// </summary>
        protected AssetLoadHandle(int controlId) {
            ControlId = controlId;
        }
    }


    public sealed class AssetLoadHandle<T> : AssetLoadHandle, IAssetLoadHandleSetter<T>
        where T : Object {

        public T Result { get; private set; }

        public UniTask<T> Task { get; private set; }


        /// <summary>
        /// Constructor.
        /// </summary>
        public AssetLoadHandle(int controlId) : base(controlId) { }

        void IAssetLoadHandleSetter<T>.SetTask(UniTask<T> task) {
            Task = task;
        }

        void IAssetLoadHandleSetter<T>.SetStatus(AssetLoadStatus status) {
            Status = status;
        }

        void IAssetLoadHandleSetter<T>.SetResult(T result) {
            Result = result;
        }

        void IAssetLoadHandleSetter<T>.SetOperationException(Exception ex) {
            OperationExeption = ex;
        }

        void IAssetLoadHandleSetter<T>.SetPercentCompleteFunc(Func<float> percentComplete) {
            PercentCompleteFunc = percentComplete;
        }
    }
}
