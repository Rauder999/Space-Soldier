using UnityEngine;
public class SpawnDecalAction : ActionBase
{
    [SerializeField] private GameObject effectPrefab;
    public override void ExecuteAction(params ActionParameter[] parametr)
    {
        if (parametr == null)
        {
            Debug.Log("DoesntWork");
            return;
        }
        foreach (var param in parametr)
        {
            if (param is HitParameter hitParameter)
            {
                var decal = Instantiate(effectPrefab);
                decal.transform.position = hitParameter.Hit.point + hitParameter.Hit.normal * 0.001f;
                decal.transform.rotation = Quaternion.LookRotation(hitParameter.Hit.normal);
                decal.transform.SetParent(hitParameter.Hit.transform);
                Destroy(decal, 5);
            }
        }
    }
}
