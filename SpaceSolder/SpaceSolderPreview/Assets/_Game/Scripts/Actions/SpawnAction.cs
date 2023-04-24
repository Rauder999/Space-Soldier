using UnityEngine;

public class SpawnAction : ActionBase
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private float delay;

    public override void ExecuteAction(params ActionParameter[] parametr)
    {
        if (objectPrefab == null) return;

        var spawnedObject = Instantiate(objectPrefab, transform.position, transform.rotation);
        Destroy(spawnedObject, delay);
    }    
}
