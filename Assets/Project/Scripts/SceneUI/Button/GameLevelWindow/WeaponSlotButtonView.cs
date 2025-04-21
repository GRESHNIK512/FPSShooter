using Buttons;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSlotButtonView : UiButton, IUiWeaponTypeListener, IUiSelectRemovedListener, IUiSelectListener
{
    [SerializeField] private int _index;
    [SerializeField] private Image _selectImage;
    [SerializeField] private Image _weaponTypeImage;
    [SerializeField] private TextMeshProUGUI _ammoCountTMP;

    public override void Init()
    {
        base.Init();
        _uiEntity.isWeaponSlotButton = true;
        _uiEntity.AddIndex(_index);
        _uiEntity.AddUiWeaponTypeListener(this);
        _uiEntity.AddUiSelectRemovedListener(this);
        _uiEntity.AddUiSelectListener(this);
    }

    public void OnSelect(UiEntity entity)
    {
       _selectImage.enabled = true;
    }

    public void OnSelectRemoved(UiEntity entity)
    {
        _selectImage.enabled = false;
    }

    public void OnWeaponType(UiEntity entity, WeaponType value)
    { 
        _weaponTypeImage.sprite = ConfigsManager.WeaponConfig.Weapons[(int)value].Sprite;
    }
} 