using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPack : MonoBehaviour, ICollectableItem
{
    [SerializeField] private Vector2Int bulletToAddRange;
    [SerializeField] private ActionBase[] executeOnCollect;

    public CollectableItems ItemType => CollectableItems.BulletPack; 

    private int _cachedResult;
    private bool _isResultCached;

    public int GetCount()
    {
        if (_isResultCached)
            return _cachedResult;

        _isResultCached = true;
        _cachedResult = Random.Range(bulletToAddRange.x, bulletToAddRange.y);
        return _cachedResult;
    }

    public void OnCollect()
    {
        if (CollectionsExtensions.IsNullOrEmpty(executeOnCollect))
            return;

        executeOnCollect.ExecuteAll();
    }

    
}
