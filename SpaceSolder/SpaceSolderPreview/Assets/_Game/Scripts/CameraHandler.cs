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
    [SerializeField] private Transform playerCenter;
    [Space]
    [SerializeField] private CameraConfig cameraConfig;
    [SerializeField] private bool leftPivot;
    [SerializeField] private float rayDistance1;
    [SerializeField] private float rayDistance2;
    [SerializeField] private float distortionPK;

    private float mouseX;
    private float mouseY;
    private float smoothX;
    private float smoothY;
    private float smoothXVelocity;
    private float smoothYVelocity;
    private float lookAngle;
    private float titlAngle;
    private float _distortionPK;
    private bool isAiming;

    private void Update()
    {
        transform.position = playerCenter.transform.position;
        HandlePosition();
        HandleRotation();
        TargetLook();
    }

    private void TargetLook()
    {
        Ray ray = new Ray(camTrans.position, camTrans.forward * rayDistance1);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            targetLook.position = Vector3.Lerp(targetLook.position, hit.point, Time.deltaTime * 40);
        }

        else
        {
            targetLook.position = Vector3.Lerp(targetLook.position, targetLook.transform.forward * rayDistance2, Time.deltaTime * 5);
        }
    }

    public void ScopeController()
    {
        isAiming = !isAiming;
    }
    void HandlePosition()
    {
        float targetX = cameraConfig.normalX;
        float targetY = cameraConfig.normalY;
        float targetZ = cameraConfig.normalZ;

        if (isAiming) 
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

        float t = Time.deltaTime * cameraConfig.pivotSpeed;
        pivot.localPosition = Vector3.Lerp(pivot.localPosition, newPivotPosition, t);
        camTrans.localPosition = Vector3.Lerp(camTrans.localPosition, newCameraPosition, t);
    }

    void HandleRotation()
    {
        if (Input.GetMouseButton(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved))
        {
            float targetRotY = Character.transform.rotation.eulerAngles.y;
            if (Input.mousePosition.x > Screen.width / 2 || Input.touchCount > 0)
            {
                if (Input.touchCount == 0 || Input.GetTouch(0).position.x > Screen.width / 2)
                {
                    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
                    {
                        mouseX = Input.GetTouch(0).deltaPosition.x;
                        mouseY = Input.GetTouch(0).deltaPosition.y;
                        _distortionPK = 0;
                    }
                    else
                    {
                        mouseX = Input.GetAxis("Mouse X");
                        mouseY = Input.GetAxis("Mouse Y");
                        _distortionPK = distortionPK;
                    }
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

                    lookAngle += smoothX * (cameraConfig.Y_rot_speed + _distortionPK);
                    Quaternion targetRot = Quaternion.Euler(0, lookAngle, 0);
                    mTransform.rotation = targetRot;

                    titlAngle -= smoothY * (cameraConfig.X_rot_speed + _distortionPK);
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
