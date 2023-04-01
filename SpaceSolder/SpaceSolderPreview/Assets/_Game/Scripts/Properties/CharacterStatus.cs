using UnityEngine;

[CreateAssetMenu(menuName = "Character/status")]
public class CharacterStatus : ScriptableObject
{
    public bool isAiming;
    public bool isSprint;
    public bool isGround;
}