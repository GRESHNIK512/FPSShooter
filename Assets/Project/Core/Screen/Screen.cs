using UnityEngine;

namespace MyScreen
{
    public abstract class Screen : MonoBehaviour
    {
        [SerializeField] private Window[] _windows;

        public virtual void Init()
        {
            foreach (var window in _windows)
            {
                window.Init();
            }
        }
    }
}