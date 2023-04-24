using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform shotPoint;
    [SerializeField] private Transform targetLook;

    [SerializeField] private Camera cameraMain;
    [SerializeField] private GameObject bullet;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private TextMeshProUGUI ammoCurrentText;
    [SerializeField] private TextMeshProUGUI ammoLeftText;
     [SerializeField] private int ammoAmount;
    [SerializeField] private int ammoLeft;
    private int _AmmoMax;

    public void StartShoot()
    {
        StartCoroutine(Fire());
        
    }

    private void Start()
    {
        ammoCurrentText.text = ammoAmount.ToString();
        ammoLeftText.text = ammoLeft.ToString();
        _AmmoMax = ammoAmount;
    }

    private IEnumerator Fire()
    {
        Instantiate(bullet, shotPoint.position, shotPoint.rotation);
        muzzleFlash.Play();
        UseAmmo(ref ammoAmount);
        if(ammoAmount == 0)
        AddAmmo(); 
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
    private void UseAmmo(ref int ammo)
    {
        if (ammo > 0)
        {
            ammo--;
            ammoCurrentText.text = ammo.ToString();
        }
    }

    public void AddAmmo()
    {
        if(ammoLeft >= _AmmoMax)
        { 
            ammoAmount = _AmmoMax;
            ammoLeft -= _AmmoMax;
            ammoCurrentText.text = ammoAmount.ToString();
            ammoLeftText.text = ammoLeft.ToString();
        Debug.Log("Reload");
        }
        else Debug.Log("AmmoLeft is over");
    }

    public void AddAmumnition(int AmmoToAdd)
    {
        ammoLeft += AmmoToAdd;
        ammoLeftText.text = ammoLeft.ToString();
    }
}
