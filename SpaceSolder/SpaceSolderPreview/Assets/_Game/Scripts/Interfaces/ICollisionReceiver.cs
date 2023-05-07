using UnityEngine;

public interface ICollisionReceiver
{
    void OnCollisionEnter(Collision other);
}
