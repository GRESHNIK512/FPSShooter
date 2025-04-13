using Core;
using DG.Tweening;
using Entitas;
using UnityEngine;

public class Root : MonoBehaviour
{
    private Contexts _contexts;
    private Systems _fixedCoreSystems;
    private Systems _gameCoreSystems; 

    private void Awake()
    {
        _contexts = Contexts.sharedInstance;
        _fixedCoreSystems = new FixedCoreSystems(_contexts);
        _gameCoreSystems = new GameCoreSystems(_contexts); 
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        _fixedCoreSystems.Initialize();
        _gameCoreSystems.Initialize(); 
        DOTween.Init();
    }

    private void FixedUpdate()
    {
        _fixedCoreSystems.Execute();
        _fixedCoreSystems.Cleanup();
    }

    private void Update()
    {
        _gameCoreSystems.Execute();
        _gameCoreSystems.Cleanup();
    } 
}