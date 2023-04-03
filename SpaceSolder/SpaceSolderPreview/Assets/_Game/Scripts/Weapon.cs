using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponProperties weaponProperties;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private Transform targetLook;

    [SerializeField] private Camera cameraMain;
    [SerializeField] private GameObject decal;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject muzzleFlash;

    public void StartShoot()
    {
        StartCoroutine(Fire());
    }

    private IEnumerator Fire()
    {
        Instantiate(bullet, shotPoint.position, shotPoint.rotation);
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        muzzleFlash.SetActive(false);
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
