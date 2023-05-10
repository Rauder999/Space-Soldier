using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ConditionGravityModifier : MonoBehaviour
{
    [SerializeField] private float power;
    [SerializeField] private float heightHigherThan;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (transform.position.y > heightHigherThan)
            _rigidbody.AddForce(Vector3.down * power, ForceMode.Force);
    }
}
