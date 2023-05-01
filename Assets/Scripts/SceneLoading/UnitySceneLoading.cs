using UnityEngine;
using Extensions;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace SceneLoading
{
    public class UnitySceneLoading : IAsyncSceneLoading
    {
        public async Task<AsyncOperation> LoadAsync(Scene scene)
        {
            return await SceneManager.LoadSceneAsync(scene.Name, scene.LoadMode);
        }

        public async Task<AsyncOperation> UnloadAsync(Scene scene)
        {
            return await SceneManager.UnloadSceneAsync(scene.Name);
        }
    }
}
