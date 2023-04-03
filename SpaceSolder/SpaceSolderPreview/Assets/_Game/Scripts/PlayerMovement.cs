using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float RUN_FORWARD_BELOW_ANGLE = 67.5f;

    [SerializeField] private Crossheir crossheir;
    [SerializeField] private Joystick joystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody rb;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

   
    private void Update()
    {
        rb.velocity = new Vector3(joystick.Horizontal * moveSpeed, rb.velocity.y, joystick.Vertical * moveSpeed);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(rb.velocity);
            float angle = Mathf.Abs(newRotation.eulerAngles.y - mainCamera.transform.eulerAngles.y);
            angle = CalibrateAngle(angle);

            if (angle < RUN_FORWARD_BELOW_ANGLE)
            {
                SetAnimationTegs(newRotation.eulerAngles.y, 50, true);
            }
            else
            {
                float yRotation = mainCamera.transform.rotation.eulerAngles.y;
                SetAnimationTegs(yRotation, 50, false);
            }
        }
        else
        {
            float yRotation = mainCamera.transform.rotation.eulerAngles.y;
            SetAnimationTegs(yRotation, 20, true, true);
        }
    }

    private void SetAnimationTegs(float yRotation, float crossheirSpread, bool isRunningForward, bool isIdle = false)
    {
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
        _animator.SetBool("IsRunningForward", isIdle ? false : isRunningForward);
        _animator.SetBool("IsRunningBackward", isIdle ? false : !isRunningForward);
        _animator.SetBool("Idle", isIdle);
        crossheir.CurrentSpread = crossheirSpread;
    }

    private float CalibrateAngle(float angle) => angle > 180 ? 360 - angle : angle;
}
