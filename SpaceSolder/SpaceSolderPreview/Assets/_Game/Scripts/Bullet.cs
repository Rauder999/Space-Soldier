using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject decalPrefab;
    Vector3 lastPos;
  
    void Start()
    {
        lastPos = transform.position;
    }

   
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        RaycastHit hit;

        Debug.DrawLine(lastPos,transform.position);
        if (Physics.Linecast(lastPos, transform.position, out hit))
        {
            print(hit.transform.name);

            GameObject decal = Instantiate<GameObject>(decalPrefab);
            decal.transform.position = hit.point + hit.normal * 0.001f;
            decal.transform.rotation = Quaternion.LookRotation(hit.normal);
            Destroy(decal, 10);
            Destroy(gameObject);
        }
        lastPos = transform.position;
    }
}
