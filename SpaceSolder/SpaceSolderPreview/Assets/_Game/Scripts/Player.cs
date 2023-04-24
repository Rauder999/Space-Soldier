using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    void OnCollisionEnter (Collision other)
    {
        if(other.transform.TryGetComponent<ICollectableItem>(out var item))
        {
            switch (item.ItemType)
            {
                case CollectableItems.BulletPack:
                    weapon.AddAmumnition(item.GetCount());
                    item.OnCollect();
                    Destroy(other.gameObject);
                    break;
            }
        }
    }
}
