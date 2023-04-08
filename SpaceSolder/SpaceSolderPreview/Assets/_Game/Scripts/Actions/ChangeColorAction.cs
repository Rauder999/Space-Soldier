using UnityEngine;

public class ChangeColorAction : ActionBase
{
    [SerializeField] private new Renderer renderer;
    [SerializeField] private int materialIndex;
    [SerializeField] private Color color;
    [SerializeField] private float intensity;

    public override void ExecuteAction()
    {
        if (renderer == null)
            return;

        renderer.materials[materialIndex].color = Color.Lerp(renderer.materials[materialIndex].color, color, intensity);
    }
}
