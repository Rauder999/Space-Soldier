using UnityEngine;

public abstract class ActionBase : MonoBehaviour
{
    public abstract void ExecuteAction();

    public static void ExecuteRange(ActionBase[] actions)
    {
        if (actions == null) 
            return;

        foreach (var action in actions)
            action.ExecuteAction();
    }
}
