using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPack : MonoBehaviour, ICollectableItem
{
    [SerializeField] private Vector2Int bulletToAddRange;
    public int GetCount()
    {
        return Random.Range(bulletToAddRange.x, bulletToAddRange.y);
    }
}
