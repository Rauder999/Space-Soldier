using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplosianAction : ActionBase
{
    [SerializeField] private ParticleSystem barrelExplosian;
     public override void ExecuteAction()
    {
        gameObject.SetActive(false);
        barrelExplosian.Play();
    }
}
