using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private Transform camTrans;
    [SerializeField] private Transform pivot;
    [SerializeField] private Transform Character;
    [SerializeField] private Transform mTransform;
    [SerializeField] private Transform targetLook;
    [Space]
    [SerializeField] private CharacterStatus characterStatus;
    [SerializeField] private CameraConfig cameraConfig;
    [SerializeField] private bool leftPivot;

    [SerializeField] private float delta;
    [SerializeField] private float mouseX;
    [SerializeField] private float mouseY;
    [SerializeField] private float smoothX;
    [SerializeField] private float smoothY;
    [SerializeField] private float smoothXVelocity;
    [SerializeField] private float smoothYVelocity;
    [SerializeField] private float lookAngle;
    [SerializeField] private float titlAngle;

    private void Update()
    {
        DeltaTime();
        HandlePosition();
        HandleRotation();
        TargetLook();


    }

    void DeltaTime()
    {
        delta = Time.deltaTime;
    }

    void TargetLook()
    {
        Ray ray = new Ray(camTrans.position, camTrans.forward * 2000);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            targetLook.position = Vector3.Lerp(targetLook.position, hit.point, Time.deltaTime * 40);
        }

        else
        {
            targetLook.position = Vector3.Lerp(targetLook.position, targetLook.transform.forward * 200, Time.deltaTime * 5);
        }
    }

    public void ScopeController()
    {
        bool _isAiming = characterStatus.isAiming;
        _isAiming = !_isAiming;
        characterStatus.isAiming = _isAiming;
    }
    void HandlePosition()
    {
        float targetX = cameraConfig.normalX;
        float targetY = cameraConfig.normalY;
        float targetZ = cameraConfig.normalZ;

        if (characterStatus.isAiming) 
        {
            targetX = cameraConfig.aimX;
            targetZ = cameraConfig.aimZ;
        }

        if(leftPivot)
        {
            targetX = -targetX;
        }

        Vector3 newPivotPosition = pivot.localPosition;
        newPivotPosition.x = targetX;
        newPivotPosition.y = targetY;

        Vector3 newCameraPosition = camTrans.localPosition;
        newCameraPosition.z = targetZ;

        float t = delta * cameraConfig.pivotSpeed;
        pivot.localPosition = Vector3.Lerp(pivot.localPosition, newPivotPosition, t);
        camTrans.localPosition = Vector3.Lerp(camTrans.localPosition, newCameraPosition, t);
    }

    void HandleRotation()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                var touch = Input.GetTouch(i);
                float targetRotY = Character.transform.rotation.eulerAngles.y;
                if (touch.position.x > Screen.width / 2)
                {
                    Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                    mouseX = touchDeltaPosition.x;
                    mouseY = touchDeltaPosition.y;

                    if (cameraConfig.turnSmooth > 0)
                    {
                        smoothX = Mathf.SmoothDamp(smoothX, mouseX, ref smoothXVelocity, cameraConfig.turnSmooth);
                        smoothY = Mathf.SmoothDamp(smoothY, mouseY, ref smoothYVelocity, cameraConfig.turnSmooth);
                    }

                    else
                    {
                        smoothX = mouseX;
                        smoothY = mouseY;
                    }

                    lookAngle += smoothX * cameraConfig.Y_rot_speed;
                    Quaternion targetRot = Quaternion.Euler(0, lookAngle, 0);
                    mTransform.rotation = targetRot;

                    titlAngle -= smoothY * cameraConfig.X_rot_speed;
                    titlAngle = Mathf.Clamp(titlAngle, cameraConfig.minAngle, cameraConfig.maxAngle);
                    pivot.localRotation = Quaternion.Euler(titlAngle, 0, 0);
                    targetRotY += smoothX * cameraConfig.Y_rot_speed;
                    Quaternion targetRotYQuaternion = Quaternion.Euler(0, targetRotY, 0);
                    Character.transform.rotation = targetRotYQuaternion;
                }
            }
        }
    }
}
