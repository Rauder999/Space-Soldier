using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlivatorAction : ActionBase
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxHight;
    [SerializeField] private float minHight;
    [SerializeField] private float waitTime;

    private bool _isMoving = true;
    private bool _isWaiting = false;

    public override void ExecuteAction(params ActionParameter[] parametr)
    {
        StartCoroutine(MoveElevator());
        IEnumerator MoveElevator()
        {
            while(true)
            {
                if(!_isWaiting)
                {
                    float targetHeight = _isMoving ? maxHight : minHight;
                    Vector3 targetPos = new Vector3(transform.position.x, targetHeight, transform.position.z);
                    transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);

                    if(Mathf.Abs(transform.position.y - targetHeight) < 0.1f)
                    {
                        _isMoving = true;
                        yield return new WaitForSeconds(waitTime);
                        _isMoving = !_isMoving;
                        _isMoving = false;
                    }
                }
                yield return null;
            }
        }
    }
}
