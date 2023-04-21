using UnityEngine;

public class DamageModifier : MonoBehaviour, IDamageReceiver
{
    [SerializeField] private BaseDamageReceiver damageReceiver;
    [SerializeField] private float addToIncommingDamage;

    public void OnGetDamage(DamageData damageData)
    {
        damageReceiver.OnGetDamage(ModifieDamage(damageData));
    }

    private DamageData ModifieDamage(DamageData damageData)
    {
        return new DamageData(damageData.Damage + addToIncommingDamage, damageData.Hit);
    }
}
