using UnityEngine;

public class DestroyAction : ActionBase
{
    [SerializeField] private float delay;

    public override void ExecuteAction(params ActionParameter[] parametr)
    {
        Destroy(gameObject, delay);
    }
}
