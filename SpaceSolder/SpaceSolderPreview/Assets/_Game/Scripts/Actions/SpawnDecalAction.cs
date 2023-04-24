using UnityEngine;

public class SpawnDecalAction : ActionBase
{
    [SerializeField] private GameObject effectPrefab;
    [SerializeField] private float delay;

    private const float _correction = 0.001f;
    public override void ExecuteAction(params ActionParameter[] parameters)
    {
        if (parameters == null)
        {
            Debug.LogError($"Action '{name}' can't execute - parrameter of type {typeof(HitParameter)} required", gameObject);
            return;
        }
        foreach (var param in parameters)
        {
            if (param is HitParameter hitParameter)
            {
                var decal = Instantiate(effectPrefab);
                decal.transform.position = hitParameter.Hit.point + hitParameter.Hit.normal * _correction;
                decal.transform.rotation = Quaternion.LookRotation(hitParameter.Hit.normal);
                decal.transform.SetParent(hitParameter.Hit.transform);
                Destroy(decal, delay);
            }
        }
    }
}
