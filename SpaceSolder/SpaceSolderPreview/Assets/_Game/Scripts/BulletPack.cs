using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPack : MonoBehaviour, ICollectableItem
{
    [SerializeField] private Vector2Int bulletToAddRange;
    [SerializeField] private ActionBase[] executeOnGetCollect;
    public int GetCount()
    {
        return Random.Range(bulletToAddRange.x, bulletToAddRange.y);
    }

    public void OnCollect()
    {
        if (CollectionsExtensions.IsNullOrEmpty(executeOnGetCollect))
            return;

        executeOnGetCollect.ExecuteAll();
    }

    
}
