using UnityEngine;

public class BaseDamageReceiver : MonoBehaviour, IDamageReceiver
{
    [SerializeField] private ActionBase[] executeOnGetDamage;
    [SerializeField] private ActionBase[] executeOnHPBelowZero;
    [SerializeField] private float armor;
    public float HP;

    public void OnGetDamage(float dmg)
    {
        var penetratedDamage = Mathf.Max(dmg - armor, 0);
        HP -= penetratedDamage;

        Debug.Log($"name {HP}", gameObject);


        if (HP <= 0)
        {
            ActionBase.ExecuteRange(executeOnHPBelowZero);
        }
        else
        {
            ActionBase.ExecuteRange(executeOnGetDamage);
        }
    }

   public void DecalSpawnAction(RaycastHit hit, GameObject decalPrefab)
    {
            var decal = Instantiate(decalPrefab);
            decal.transform.position = hit.point + hit.normal * 0.001f;
            decal.transform.rotation = Quaternion.LookRotation(hit.normal);
            decal.transform.SetParent(hit.transform);
            Destroy(decal, 5);
    }
}
