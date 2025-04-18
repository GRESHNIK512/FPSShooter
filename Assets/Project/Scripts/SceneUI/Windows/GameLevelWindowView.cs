using TMPro;
using UnityEngine;

public class GameLevelWindowView : Window, IUiHpListener
{  
    [SerializeField] private Joystick _joystick;
    [SerializeField] private TextMeshProUGUI _hpTmp;

    private int _lastHp = 0;
    private int _roundHp = 0;

    public override void Init()
    {
        base.Init();
        _uiEntity.isGameLevelWindow = true;
        _uiEntity.AddJoystick(_joystick);

        _uiEntity.AddUiHpListener(this);
    } 

    public void OnHp(UiEntity entity, float value)
    { 
        _roundHp = Mathf.CeilToInt(value);
        
        if (_lastHp != _roundHp)
        {
            _hpTmp.text = $"{_roundHp}";
            _lastHp = _roundHp;
        }
    }
} 