using UnityEngine;

public class BarrelExplosianAction : ActionBase
{
    [SerializeField] private ParticleSystem barrelExplosian;
     public override void ExecuteAction(params ActionParameter[] parametr)
    {
        gameObject.SetActive(false);
        barrelExplosian.Play();
    }
}
