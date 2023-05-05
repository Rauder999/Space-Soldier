using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform weaponHolder;
    [SerializeField] private Transform targetLook;
    [SerializeField] private Weapon weapon;

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
        _UIManager.SubscribeOn(UIManager.ButtonTypes.ButtonFire, weapon.Shoot);
        _UIManager.SubscribeOn(UIManager.ButtonTypes.ButtonFireStop, weapon.Stop);
        _UIManager.SubscribeOn(UIManager.ButtonTypes.ButtonThrow, ChangeWeapon);
        weapon.Init(uIManager, this, weaponHolder, targetLook);
    }

    private void ChangeWeapon()
    {
        if (_lastSavedWeapon == null)
            return;

        if (weapon)
        {
            _UIManager.RemoveListener(UIManager.ButtonTypes.ButtonFire, weapon.Shoot);
            _UIManager.RemoveListener(UIManager.ButtonTypes.ButtonFireStop, weapon.Stop);
            weapon.Throw();
        }

        weapon = _lastSavedWeapon as Weapon;
        _UIManager.SubscribeOn(UIManager.ButtonTypes.ButtonFire, weapon.Shoot);
        _UIManager.SubscribeOn(UIManager.ButtonTypes.ButtonFireStop, weapon.Stop);

        weapon.Init(_UIManager, this, weaponHolder, targetLook);
        weapon.OnCollect();
    }
}
