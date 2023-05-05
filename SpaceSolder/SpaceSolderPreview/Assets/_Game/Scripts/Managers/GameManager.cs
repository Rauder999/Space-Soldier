using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uIManager;
    [SerializeField] private Player player;
    [SerializeField] private SceneConstructor sceneConstructor;

    private void Awake()
    {
        player.Init(uIManager);
        sceneConstructor.Init();
    }
}
