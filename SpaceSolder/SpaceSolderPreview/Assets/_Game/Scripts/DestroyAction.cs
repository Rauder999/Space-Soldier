using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAction : ActionBase
{
    [SerializeField] private float delay;
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
    public override void ExecuteAction()
    {
        skinnedMeshRenderer.GetComponent<SkinnedMeshRenderer>().materials[0].color = Color.red;
        Destroy(gameObject, delay);
    }
}
