using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    private UIManager _UIManager;
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
            }
        }
    }

    public void Init(UIManager uIManager)
    {
        _UIManager = uIManager;
        weapon.Init(uIManager);
    }
}
