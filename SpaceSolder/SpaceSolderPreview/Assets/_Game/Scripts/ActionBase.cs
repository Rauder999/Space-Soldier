using UnityEngine;

public abstract class ActionBase : MonoBehaviour
{
    public abstract void ExecuteAction(params ActionParameter[] parameters);

    public static void ExecuteRange(ActionBase[] actions, params ActionParameter[] parameters)
    {
        if (actions == null) 
            return;

        foreach (var action in actions)
            action.ExecuteAction(parameters);
    }
}


public abstract class ActionParameter
{

}