
namespace Project.BatchProcessor{
    
    public interface ISystemBase{

        /// <summary>
        /// Process order.
        /// </summary>
        int Order { get; }
    }


    public interface IEarlyUpdate : ISystemBase {
        void OnUpdate();
    }

    public  interface IPostUpdate : ISystemBase {
        void OnLateUpdate();
    }
}