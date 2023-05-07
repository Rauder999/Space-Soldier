using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform weaponHolder;
    [SerializeField] private Transform targetLook;
    [SerializeField] private Weapon weapon;
    [SerializeField] private BaseCollisionReceiver baseCollision;

    private UIManager _UIManager;
    private ICollectableItem _lastSavedWeapon;

    void OnCollisionEnter (Collision other)
    {
        if(other.transform.TryGetComponent<ICollectableItem>(out var item))
        {
            switch (item.ItemType)
            {
                case CollectableItems.BulletPack:
                    weapon.AddAmmo(item.GetCount());
                    item.OnCollect();
                    Destroy(other.gameObject);
                    break;
                case CollectableItems.Weapon:
                    _UIManager.SetActiveButton(UIManager.ButtonTypes.ButtonThrow, true);
                    _lastSavedWeapon = item;
                    break;
            }
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.transform.TryGetComponent<ICollectableItem>(out var item))
        {
            switch (item.ItemType)
            {
                case CollectableItems.Weapon:
                    if(item == _lastSavedWeapon)
                    {
                        _UIManager.SetActiveButton(UIManager.ButtonTypes.ButtonThrow, false);
                        _lastSavedWeapon = null;
                    }
                    break;
            }
        }
    }
    
    public void Init(UIManager uIManager)
    {
        _UIManager = uIManager;
        SubscribeWeaponOnInput();
        _UIManager.SubscribeOn(UIManager.ButtonTypes.ButtonThrow, ChangeWeapon);
        weapon.Init(uIManager, this, weaponHolder, targetLook);
    }

    private void ChangeWeapon()
    {
        if (_lastSavedWeapon == null)
            return;

        if (weapon)
        {
            RemoveWeaponOnInput();
            weapon.Throw();
        }

        weapon = _lastSavedWeapon as Weapon;
        SubscribeWeaponOnInput();

        weapon.Init(_UIManager, this, weaponHolder, targetLook);
        weapon.OnCollect();
    }

    private void SubscribeWeaponOnInput()
    {
        _UIManager.SubscribeOn(UIManager.ButtonTypes.ButtonFire, weapon.Shoot);
        _UIManager.SubscribeOn(UIManager.ButtonTypes.ButtonFireStop, weapon.Stop);
    }

    private void RemoveWeaponOnInput()
    {
        if (weapon != null)
        {
            _UIManager.RemoveListener(UIManager.ButtonTypes.ButtonFire, weapon.Shoot);
            _UIManager.RemoveListener(UIManager.ButtonTypes.ButtonFireStop, weapon.Stop);
        }
    }

}
