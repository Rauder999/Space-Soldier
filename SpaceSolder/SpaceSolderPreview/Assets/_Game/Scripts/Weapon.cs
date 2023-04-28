using System.Collections;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform shotPoint;
    [SerializeField] private Transform targetLook;

    [SerializeField] private Camera cameraMain;
    [SerializeField] private GameObject bullet;
    [SerializeField] private ParticleSystem muzzleFlash;
    //[SerializeField] private TextMeshProUGUI ammoCurrentText;
    //[SerializeField] private TextMeshProUGUI ammoLeftText;
    [SerializeField] private int ammoAmount;
    [SerializeField] private int ammoLeft;
    private int _AmmoMax;
    private UIManager _UIManager;

    public void StartShoot()
    {
        StartCoroutine(Fire());
        
    }

    public void Init(UIManager uIManager)
    {
        _UIManager = uIManager;
    }

    private void Start()
    {
        _UIManager.SetText(UIManager.TextFieldKeys.ammoCurrentText, ammoAmount.ToString());
        //ammoCurrentText.text = ammoAmount.ToString();
        _UIManager.SetText(UIManager.TextFieldKeys.ammoLeftText, ammoLeft.ToString());
        //ammoLeftText.text = ammoLeft.ToString();
        _AmmoMax = ammoAmount;
    }

    private IEnumerator Fire()
    {
        if (ammoAmount > 0)
        {
            Instantiate(bullet, shotPoint.position, shotPoint.rotation);
            muzzleFlash.Play();
            UseAmmo(ref ammoAmount);
        }
        if (ammoAmount == 0)
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
            //ammoCurrentText.text = ammo.ToString();
            _UIManager.SetText(UIManager.TextFieldKeys.ammoCurrentText, ammo.ToString());
        }
    }

    public void AddAmmo()
    {
        if (ammoLeft > 0)
        {
            if(ammoLeft < _AmmoMax)
            {
                ammoAmount = ammoLeft;
                ammoLeft -= ammoLeft;
            }
            else
            {
                ammoAmount = _AmmoMax;
                ammoLeft -= _AmmoMax;
            }

            //ammoLeftText.text = ammoLeft.ToString();
            _UIManager.SetText(UIManager.TextFieldKeys.ammoLeftText, ammoLeft.ToString());
            //ammoCurrentText.text = ammoAmount.ToString();
            _UIManager.SetText(UIManager.TextFieldKeys.ammoCurrentText, ammoAmount.ToString());

            Debug.Log("Reload");
        }
        else
        {
            Debug.Log("AmmoLeft is over");
        }
    }

    public void AddAmumnition(int AmmoToAdd)
    {
        ammoLeft += AmmoToAdd;
        //ammoLeftText.text = ammoLeft.ToString();
        _UIManager.SetText(UIManager.TextFieldKeys.ammoLeftText, ammoLeft.ToString());
    }
}
