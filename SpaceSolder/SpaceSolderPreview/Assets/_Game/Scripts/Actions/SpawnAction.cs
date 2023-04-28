using UnityEngine;

public class SpawnAction : ActionBase
{
    [SerializeField] private GameObject objectPrefab;
    public override void ExecuteAction(params ActionParameter[] parametr)
    {
        if (objectPrefab == null) return;

        var spawnedObject = Instantiate(objectPrefab, transform.position, transform.rotation);
        // i left var for a future
        
    }    
}
