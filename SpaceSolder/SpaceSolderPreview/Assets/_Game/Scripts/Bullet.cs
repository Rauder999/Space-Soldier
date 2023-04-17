using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float dmg;
    [SerializeField] private GameObject decalPrefab;
    [SerializeField] private GameObject bloodDecalPrefab;
    [SerializeField] private BaseDamageReceiver baseDamage;

    private Vector3 lastPos;
  
    void Start()
    {
        lastPos = transform.position;
    }
   
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        Debug.DrawLine(lastPos, transform.position);
        RaycastHit hit;

        if (Physics.Linecast(lastPos, transform.position, out hit))
        {

            if (hit.transform.TryGetComponent<IDamageReceiver>(out var damageReceiver))
            {
                damageReceiver.OnGetDamage(dmg);
            }
            if (hit.transform.CompareTag("Enemy"))
            {
                baseDamage.DecalSpawnAction(hit, bloodDecalPrefab);
            }
            else
            {
                baseDamage.DecalSpawnAction(hit, decalPrefab);
            }
            Destroy(gameObject);
        }
        
        lastPos = transform.position;
    }
}
