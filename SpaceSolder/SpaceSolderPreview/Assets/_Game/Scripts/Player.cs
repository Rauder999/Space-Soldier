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
            if(item is BulletPack bulletPack)
            {
                weapon.AddAmumnition(bulletPack.GetCount());
                Destroy(other.gameObject);
            }
        }
    }
}
