using UnityEngine;

public class LevelInitView : LevelObject 
{
    [SerializeField] private SpawnerView[] _spawners;

    private void Awake()
    {
        base.Init();
        _gameEntity.isLevel = true; 

        var levelManagerEnt = Contexts.sharedInstance.game.levelManagerEntity;
        if (levelManagerEnt != null)
        {
            levelManagerEnt.isLevelStartInit = true;

            foreach (var spawner in _spawners)
            {
                spawner.Init();
            }

            levelManagerEnt.isStartLoadLevel = false;
        }
    } 
} 