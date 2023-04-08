using UnityEngine;

public class DestroyAction : ActionBase
{
    [SerializeField] private float delay;

    public override void ExecuteAction()
    {
        Destroy(gameObject, delay);
    }
}
