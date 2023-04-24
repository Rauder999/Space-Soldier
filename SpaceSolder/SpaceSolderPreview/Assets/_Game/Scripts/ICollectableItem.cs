using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectableItem
{
    public int GetCount();

    public void OnCollect();
}
