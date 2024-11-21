using UnityEngine;

namespace nitou.AssetLoader{

    [CreateAssetMenu(
        fileName = "ResourcesAssetLoader", 
        menuName = "Resource Loader/Resources Asset Loader"
    )]
    public sealed class ResourcesAssetLoaderObject : AssetLoaderSO, IAssetLoader{

        private readonly ResourcesAssetLoader _loader = new ();

        public override AssetLoadHandle<T> Load<T>(string key) => _loader.Load<T>(key);

        public override AssetLoadHandle<T> LoadAsync<T>(string key) => _loader.LoadAsync<T>(key);

        public override void Release(AssetLoadHandle handle) => _loader.Release(handle);

    }
}