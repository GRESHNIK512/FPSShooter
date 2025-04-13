using UnityEngine;

public class BotView : Unit, IUnitRotationListener
{
    [SerializeField] private Transform _unitModelTranform; 

    public override void Init()
    {
        base.Init();
        _gameEntity.AddUnitRotationListener(this);
    }

    public void OnUnitRotation(GameEntity entity, Vector3 value)
    {
        var _currentModelRotation = _unitModelTranform.rotation;
        var _currentWeaponRotation = _weaponTranform.localRotation;

        // Целевое вращение (меняем только ось Y)
        var _nextModelRotation = Quaternion.Euler(
            _currentModelRotation.eulerAngles.x,
            value.y,
            _currentModelRotation.eulerAngles.z
        );

        // Плавный поворот
        _unitModelTranform.localRotation = Quaternion.Slerp(
            _currentModelRotation,
            _nextModelRotation,
            ConfigsManager.BotConfig.RotationSpeed * Time.deltaTime
        );

        var _nextWeapononRotation = Quaternion.Euler(
            value.x,
           _currentWeaponRotation.eulerAngles.y,
           _currentWeaponRotation.eulerAngles.z
       );  

        // Плавный поворот
        _weaponTranform.localRotation = Quaternion.Slerp(
            _currentWeaponRotation,
            _nextWeapononRotation,
            ConfigsManager.BotConfig.RotationSpeed * Time.deltaTime
        );
    }
}