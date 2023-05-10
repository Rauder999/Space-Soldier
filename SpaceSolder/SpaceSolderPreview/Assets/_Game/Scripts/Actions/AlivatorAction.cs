using System.Collections;
using UnityEngine;

public class AlivatorAction : ActionBase
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxHeight;

    private Coroutine _corotine;
    private Vector3 _startPosition;

    private void Awake()
    {
        _startPosition = transform.position;
    }

    public override void ExecuteAction(params ActionParameter[] parametr)
    {
        if (_corotine != null)
        {
            transform.position = _startPosition;
            StopCoroutine(_corotine);
        }

        _corotine = StartCoroutine(MoveElevator());
    }

    IEnumerator MoveElevator()
    {
        while (transform.position.y < maxHeight)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = _startPosition;
        _corotine = null;
    }
}
