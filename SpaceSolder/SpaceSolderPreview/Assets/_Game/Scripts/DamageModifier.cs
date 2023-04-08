using UnityEngine;

public class DamageModifier : MonoBehaviour, IDamageReceiver
{
    [SerializeField] private BaseDamageReceiver damageReceiver;
    [SerializeField] private float addToIncommingDamage;

    public void OnGetDamage(float dmg)
    {
        damageReceiver.OnGetDamage(ModifieDamage(dmg));
    }

    private float ModifieDamage(float dmg)
    {
        return dmg + addToIncommingDamage;
    }
}
