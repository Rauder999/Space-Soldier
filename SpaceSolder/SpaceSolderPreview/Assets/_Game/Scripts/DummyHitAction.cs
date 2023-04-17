using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyHitAction : MonoBehaviour
{
    [SerializeField] private GameObject bloodDecalPrefab;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit");
        if(collision.transform.TryGetComponent<Bullet>(out var bullet))
        {
            var bloodDecal = Instantiate(bloodDecalPrefab);
            bloodDecal.transform.position = collision.transform.position;
            bloodDecal.transform.rotation = collision.transform.rotation;

            Destroy(bloodDecal, 5);
        }
    }
}
