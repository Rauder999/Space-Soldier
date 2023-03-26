using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Crossheir crossheir;
    [SerializeField] private Joystick joystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody rb;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

   
    void Update()
    {
        rb.velocity = new Vector3(joystick.Horizontal * moveSpeed, rb.velocity.y, joystick.Vertical * moveSpeed);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(rb.velocity);
            float angle = Mathf.Abs(newRotation.eulerAngles.y - mainCamera.transform.eulerAngles.y);
            if(angle > 180)
            {
                angle = 360 - angle;
            }
            if (angle < 135/2)
            {
                transform.rotation = Quaternion.Euler(0, newRotation.eulerAngles.y, 0);
                _animator.SetBool("IsRunningForward", true);
                _animator.SetBool("IsRunningBackward", false);
                _animator.SetBool("Idle", false);
                crossheir.currentSpread = 50;
            }
            else
            {
                float yRotation = mainCamera.transform.rotation.eulerAngles.y;
                transform.rotation = Quaternion.Euler(0, yRotation, 0);
                _animator.SetBool("IsRunningForward", false);
                _animator.SetBool("IsRunningBackward", true);
                _animator.SetBool("Idle", false);
                crossheir.currentSpread = 50;
            }
        }
        else
        {
            float yRotation = mainCamera.transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0, yRotation, 0);
            _animator.SetBool("IsRunningForward", false);
            _animator.SetBool("IsRunningBackward", false);
            _animator.SetBool("Idle", true);
            crossheir.currentSpread = 20;
        }
    }
}
