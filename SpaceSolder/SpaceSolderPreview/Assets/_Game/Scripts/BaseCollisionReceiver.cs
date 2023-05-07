using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollisionReceiver : MonoBehaviour, ICollisionReceiver
{
    [SerializeField] private ActionBase[] executeOnCollisionEnter;
    [SerializeField] private List<string> collisionTags;

    private UIManager _UIManager;

    public void OnCollisionEnter(Collision collision)
    {
        if(!executeOnCollisionEnter.IsNullOrEmpty())
        {
            foreach(var tag in collisionTags)
            {
                if(collision.gameObject.tag == tag)
                {
                    executeOnCollisionEnter.ExecuteAll();
                    return;
                }

                else
                {
                    //do something
                }
            }
            
        }
    }
}
