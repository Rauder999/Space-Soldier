using UnityEngine;

public abstract class Weapon : MonoBehaviour, IThrowable, ICollectableItem
{
    [SerializeField] protected Transform shotPoint;
    [SerializeField] protected Transform targetLook;
    [SerializeField] private Transform weaponPos;
    [Space]
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected ParticleSystem shootEffect;
    [Space]
    [SerializeField] protected int maxAmmo;
    [SerializeField] protected int startAmmo;
    [SerializeField] protected int ammoPerShoot;

    private UIManager _UIManager;
    private Camera _cameraMain;
    private Player _player;

    public int CurrentAmmo
    {
        get => _currentAmmo;
        set
        {
            _currentAmmo = value;
            _UIManager.SetText(UIManager.TextFieldKeys.AmmoCurrentText, _currentAmmo.ToString());
        }
    }
    public Weapon currentWeapon;
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


    public void Init(UIManager uIManager, Player player)
    {
        OnInit();
        _UIManager = uIManager;
        _cameraMain = Camera.main;
        _player = player;
        currentWeapon = this;


        FreeAmmo = startAmmo;
        Reload();
    }

    public abstract void OnInit();

    public abstract void Shoot();

    public abstract void Stop();

    void Update()
    {
        Vector3 origin = shotPoint.position;
        Vector3 dir = targetLook.position;

        Debug.DrawLine(origin, dir, Color.red);
        shotPoint.transform.LookAt(targetLook);
        //Debug.DrawLine(_cameraMain.transform.position, dir, Color.red);
    }

    private protected void SpendAmmo(int amount)
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

    public virtual void Reload()
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



    public CollectableItems ItemType => CollectableItems.Weapon;

    public int GetCount()
    {
        return 1;
    }

    public void OnCollect()
    {
        currentWeapon.transform.parent = _player.transform;
        currentWeapon.transform.position = weaponPos.position;
        currentWeapon.transform.rotation = weaponPos.rotation;
        Destroy(GetComponent<Rigidbody>());
        Destroy(GetComponent<BoxCollider>());
    }


    public ICollectableItem Throw()
    {
        currentWeapon.gameObject.transform.parent = null;
        BoxCollider boxCollider = currentWeapon.gameObject.AddComponent<BoxCollider>();
        Rigidbody rb = currentWeapon.gameObject.AddComponent<Rigidbody>();
        rb.AddForce(transform.forward);

        return this;
    }
}
