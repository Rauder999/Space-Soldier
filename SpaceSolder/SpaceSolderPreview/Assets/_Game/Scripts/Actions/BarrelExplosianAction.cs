using UnityEngine;

public class BarrelExplosianAction : ActionBase
{
    [SerializeField] private ParticleSystem barrelExplosian;
    public override void ExecuteAction(params ActionParameter[] parametr)
    {
        if (barrelExplosian == null)
            return;

        gameObject.SetActive(false);
        barrelExplosian.Play();
    }
}
