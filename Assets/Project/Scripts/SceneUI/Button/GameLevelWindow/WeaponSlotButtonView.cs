using Buttons;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSlotButtonView : UiButton, IUiEquipmentTypeListener, IUiSelectRemovedListener, IUiSelectListener,
    IUiMagazineAmmoListener, IUiTimeReloadListener, IUiReloadingListener
{
    [SerializeField] private int _index;
    [SerializeField] private Image _bacgroundImage;
    [SerializeField] private Image _reloadImage;
    [SerializeField] private Image _weaponTypeImage;
    [SerializeField] private TextMeshProUGUI _ammoCountTMP;

    private float _timeReload;

    public override void Init()
    {
        base.Init();
        _uiEntity.isWeaponSlotButton = true;
        _uiEntity.AddIndex(_index);
        _uiEntity.AddUiEquipmentTypeListener(this);
        _uiEntity.AddUiSelectRemovedListener(this);
        _uiEntity.AddUiSelectListener(this);
        _uiEntity.AddUiMagazineAmmoListener(this);
        _uiEntity.AddUiReloadingListener(this);
        _uiEntity.AddUiTimeReloadListener(this);
    }

    public void OnMagazineAmmo(UiEntity entity, int value)
    {
        _ammoCountTMP.color = value == 0 ? Color.red : Color.white;
        _ammoCountTMP.text = $"{value}";
    }

    public void OnReloading(UiEntity entity, float value)
    { 
        float percent = value / _timeReload;
        _reloadImage.enabled = percent > 0.01f;
        _reloadImage.fillAmount = percent;
    }

    public void OnSelect(UiEntity entity)
    {
        _bacgroundImage.color = ConfigsManager.WeaponConfig.SelectColor;
    }

    public void OnSelectRemoved(UiEntity entity)
    {
        _bacgroundImage.color = ConfigsManager.WeaponConfig.BackgroundColor;
        _reloadImage.enabled = false;
    }

    public void OnTimeReload(UiEntity entity, float value)
    {
        _timeReload = value;
    }

    public void OnEquipmentType(UiEntity entity, EquipmentType value)
    { 
        _weaponTypeImage.sprite = ConfigsManager.EquipmentConfig.EquipmentSettings[(int)value].Sprite;
    }
} 