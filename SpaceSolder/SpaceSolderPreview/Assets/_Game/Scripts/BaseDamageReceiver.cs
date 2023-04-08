using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDamageReceiver : MonoBehaviour, IDamageReceiver
{
    [SerializeField] private float armor;
    [SerializeField] private DamageReceiver _damageReceiver;


    public void OnGetDamage(float dmg)
    {
        armor = armor >= dmg ? dmg : armor;
        _damageReceiver.HP -= (dmg - armor);
        print(name+ ": " + _damageReceiver.HP);
        if (_damageReceiver.HP <= 0)
        {
           _damageReceiver.GetComponent<DestroyAction>().ExecuteAction();
        }
    }
}
