using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    
    private UIManager _UIManager;
    private ICollectableItem _lastCollectedCollectable;
    private GameObject newWeapon;
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
                    _lastCollectedCollectable = item;
                    newWeapon = other.gameObject;
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
                case CollectableItems.BulletPack:
                    break;
                case CollectableItems.Weapon:
                    if(item == _lastCollectedCollectable)
                    {
                        _UIManager.SetActiveButton(UIManager.ButtonTypes.ButtonThrow, false);
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
        weapon.Init(uIManager, this);
    }

    private void ChangeWeapon()
    {
        if (weapon.currentWeapon != null)
        {
            weapon.currentWeapon?.Throw();
            _UIManager.RemoveListener(UIManager.ButtonTypes.ButtonFire, weapon.Shoot);
            weapon = newWeapon.GetComponent<Weapon>();
            weapon.Init(_UIManager, this);
            _UIManager.SubscribeOn(UIManager.ButtonTypes.ButtonFire, weapon.Shoot);
            weapon.OnCollect();
        }
        else
        {
            //weapon.OnCollect();
            //weapon.currentWeapon = GetComponent<Weapon>();
        }
    }
}
