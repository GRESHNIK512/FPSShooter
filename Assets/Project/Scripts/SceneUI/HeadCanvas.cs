using UnityEngine;

namespace MyScreen
{
    public class HeadCanvas : MonoBehaviour
    {
        [SerializeField] Screen[] _screens;

        private void Awake()
        {
            foreach (var screen in _screens)
            {
                screen.Init();
            } 
            Contexts.sharedInstance.ui.CreateEntity().AddTrigRefreshStatusWindowDelay(0f);
                   //GameConfig.DefaultDelayRefreshWindow);
        }
    }
}
