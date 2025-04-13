using UnityEngine;

public class PlayerView : Unit, IVelocityListener, IJumpListener, ICameraPositionListener,
    ICaplsuleHeightListener, IUnitRotationListener
{
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private Rigidbody _rigidbody; 
    [SerializeField] private CapsuleCollider _capsuleCollider;
    [SerializeField] private Transform[] aimPoints;
    private float _oldHeight;

    public override void Init()
    {
        base.Init();
        _gameEntity.isPlayer = true;
        
        _gameEntity.AddRigidBody(_rigidbody);
        _gameEntity.AddCamera(_playerCamera);

        _gameEntity.AddCameraOriginalPosition(_playerCamera.transform.localPosition); 
        _gameEntity.AddCaplsuleOriginalHeight(_capsuleCollider.height);

        _gameEntity.AddCameraPosition(_playerCamera.transform.localPosition);
        _gameEntity.AddCaplsuleHeight(_capsuleCollider.height);
        _gameEntity.AddSitDown(false);
        _gameEntity.AddCapsuleCollider(_capsuleCollider);
        _gameEntity.AddPlayerShootPoints(aimPoints);

        _gameEntity.AddVelocityListener(this); 
        _gameEntity.AddJumpListener(this);
        _gameEntity.AddCameraPositionListener(this);
        _gameEntity.AddCaplsuleHeightListener(this);
        _gameEntity.AddUnitRotationListener(this);
    }

    public void OnCameraPosition(GameEntity entity, Vector3 value)
    {
        _playerCamera.transform.localPosition = value;
    }

    public void OnUnitRotation(GameEntity entity, Vector3 value)
    {
        transform.localRotation = Quaternion.Euler(transform.localRotation.x, value.y, transform.localRotation.z);
        _playerCamera.transform.localRotation = Quaternion.Euler(value.x, transform.localRotation.y, transform.localRotation.z);
    }

    public void OnCaplsuleHeight(GameEntity entity, float value)
    {
       _capsuleCollider.height = value;
        if (value > _oldHeight) 
            _rigidbody.AddForce(Vector3.up * 0.5f,ForceMode.Acceleration);
       _oldHeight = value;
    }

    public void OnJump(GameEntity entity, Vector3 value)
    { 
        _rigidbody.AddForce(value, ForceMode.VelocityChange);
    }

    public void OnVelocity(GameEntity entity, Vector3 value)
    {
        _rigidbody.velocity = new Vector3(value.x, _rigidbody.velocity.y, value.z); 
    }
} 