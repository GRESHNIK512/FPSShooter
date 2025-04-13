using UnityEngine;
using Zenject;

public class HeadInstaller : MonoInstaller
{
    //[SerializeField] private PlayerConfig _playerConfig;
   
    public override void InstallBindings()
    {
        //Container.BindInstance(_playerConfig).AsSingle();
    }
}