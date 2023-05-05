using System.Collections;
using UnityEngine;

public class TommyGun : Weapon
{
    [SerializeField] float corotaineDeley;
    private Coroutine _ShootCoroutine;
    private bool isShooting;


    public override void OnInit() { }

    public override void Shoot()
    {
        isShooting = true;
        _ShootCoroutine = StartCoroutine(ShootCoroutine());
    }

    IEnumerator ShootCoroutine()
    {
        while (isShooting)
        {
            if (CurrentAmmo > 0)
            {
                Instantiate(bullet, shotPoint.position, shotPoint.rotation);
                shootEffect.Play();
                SpendAmmo(ammoPerShoot);
            }

            if (CurrentAmmo == 0)
            {
                Reload();
            }

            yield return new WaitForSeconds(corotaineDeley);
        }
    }

    public override void Stop()
    {
        if (_ShootCoroutine != null)
        {
            StopCoroutine(_ShootCoroutine);
            isShooting = false;
        }
    }
}
