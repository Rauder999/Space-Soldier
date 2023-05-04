using UnityEngine;

public class Pisto : Weapon
{
    public override void Shoot()
    {
        if (CurrentAmmo > 0)
        {
            Instantiate(bullet, shotPoint.position, shotPoint.rotation);
            shootEffect.Play();
            SpendAmmo(ammoPerShoot);
        }

        if (CurrentAmmo == 0)
            Reload();
    }       

    public override void OnInit()
    {
        
    }

    public override void Stop()
    {
        
    }
}
