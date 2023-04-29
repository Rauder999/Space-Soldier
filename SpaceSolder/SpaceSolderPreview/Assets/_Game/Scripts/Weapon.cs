using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform shotPoint;
    [SerializeField] private Transform targetLook;
    [Space]
    [SerializeField] private GameObject bullet;
    [SerializeField] private ParticleSystem shootEffect;
    [Space]
    [SerializeField] private int maxAmmo;
    [SerializeField] private int startAmmo;
    [SerializeField] private int ammoPerShoot;

    private UIManager _UIManager;
    private Camera _cameraMain;

    public int CurrentAmmo
    {
        get => _currentAmmo;
        set
        {
            _currentAmmo = value;
            _UIManager.SetText(UIManager.TextFieldKeys.AmmoCurrentText, _currentAmmo.ToString());
        }
    }
    private int _currentAmmo;

    public int FreeAmmo
    {
        get => _freeAmmo;
        set
        {
            _freeAmmo = value;
            _UIManager.SetText(UIManager.TextFieldKeys.AmmoLeftText, _freeAmmo.ToString());
        }
    }
    private int _freeAmmo;


    public void Init(UIManager uIManager)
    {
        _UIManager = uIManager;
        _cameraMain = Camera.main;

        FreeAmmo = startAmmo;
        Reload();
    }

    public void Shoot()
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

    void Update()
    {
        Vector3 origin = shotPoint.position;
        Vector3 dir = targetLook.position;

        Debug.DrawLine(origin, dir, Color.red);
        shotPoint.transform.LookAt(targetLook);
        Debug.DrawLine(_cameraMain.transform.position, dir, Color.red);  
    }

    private void SpendAmmo(int amount)
    {
        if (CurrentAmmo > amount)
        {
            CurrentAmmo -= amount;
            return;
        }

        CurrentAmmo = 0;
    }

    public void AddAmmo(int amount)
    {
        FreeAmmo += amount;
    }

    public void Reload()
    {
        if (FreeAmmo > maxAmmo)
        {
            CurrentAmmo = maxAmmo;
            FreeAmmo -= maxAmmo;
            return;
        }

        if (FreeAmmo > 0)
        {
            CurrentAmmo = FreeAmmo;
            FreeAmmo = 0;
        }
    }
}
