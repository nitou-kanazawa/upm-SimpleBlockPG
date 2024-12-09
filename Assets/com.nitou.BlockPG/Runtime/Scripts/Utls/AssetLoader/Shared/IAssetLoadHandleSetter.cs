using System;
using Cysharp.Threading.Tasks;

namespace nitou.AssetLoader{

    public interface IAssetLoadHandleSetter<T>{

        void SetStatus(AssetLoadStatus status);

        void SetResult(T result);

        void SetPercentCompleteFunc(Func<float> percentComplete);

        void SetTask(UniTask<T> task);

        void SetOperationException(Exception ex);
    }
}