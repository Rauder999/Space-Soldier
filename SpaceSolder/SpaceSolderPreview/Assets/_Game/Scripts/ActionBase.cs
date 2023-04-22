using UnityEngine;

public abstract class ActionBase : MonoBehaviour
{
    public abstract void ExecuteAction(params ActionParameter[] parameters);
}


public abstract class ActionParameter
{

}