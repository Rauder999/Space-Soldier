using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform shotPoint;
    [SerializeField] private Transform targetLook;

    [SerializeField] private Camera cameraMain;
    [SerializeField] private GameObject bullet;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private Reload _reload;

    public int weaponChambler;
    public void StartShoot()
    {
        StartCoroutine(Fire());
        
    }

    private IEnumerator Fire()
    {
        Instantiate(bullet, shotPoint.position, shotPoint.rotation);
        muzzleFlash.Play();
        _reload.BulletCounter();
        yield return new WaitForSeconds(0.2f);
    }

    void Update()
    {
        Vector3 origin = shotPoint.position;
        Vector3 dir = targetLook.position;

        Debug.DrawLine(origin, dir, Color.red);
        shotPoint.transform.LookAt(targetLook);
        Debug.DrawLine(cameraMain.transform.position, dir, Color.red);  
    }
}
