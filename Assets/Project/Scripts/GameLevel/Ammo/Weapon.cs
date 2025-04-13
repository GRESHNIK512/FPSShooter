using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : LevelObject
{
    public override void Init()
    {
        base.Init();
        _gameEntity.isWeapon = true;
    }
} 