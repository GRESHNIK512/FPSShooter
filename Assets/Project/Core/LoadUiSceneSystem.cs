using Entitas; 
using UnityEngine.SceneManagement;

namespace Core
{
    internal class LoadUiSceneSystem : IInitializeSystem
    {
        public void Initialize()
        { 
            //Debug.LogWarning("LoadUiSceneSystem");
            SceneManager.LoadSceneAsync("SceneUI", LoadSceneMode.Additive);
        }
    }
}