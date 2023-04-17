public class SpawnDecalAction : ActionBase
{
    public override void ExecuteAction(params ActionParameter[] parametr)
    {
        if (parametr == null)
            return;

        foreach (var param in parametr)
        {
            if (param is HitParameter hitParameter)
            {
                // TODO: add spawn decallogic
            }
        }
    }
}
