using UnityEngine;

public class HitParameter : ActionParameter
{
    public readonly RaycastHit Hit;

    public HitParameter(RaycastHit hit)
    {
        Hit = hit;
    }
}
