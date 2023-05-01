using UnityEngine;
using System.Threading.Tasks;

namespace SceneLoading
{
    public interface IAsyncSceneLoading
    {
        Task<AsyncOperation> LoadAsync(Scene scene);
        Task<AsyncOperation> UnloadAsync(Scene scene);
    }
}
