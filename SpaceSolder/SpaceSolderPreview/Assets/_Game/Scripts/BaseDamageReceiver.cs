using UnityEngine;

public class BaseDamageReceiver : MonoBehaviour, IDamageReceiver
{
    [SerializeField] private ActionBase[] executeOnGetDamage;
    [SerializeField] private ActionBase[] executeOnHPBelowZero;
    [SerializeField] private float armor;
    [SerializeField] private float HP;

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
}
