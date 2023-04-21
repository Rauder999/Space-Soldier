using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reload : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private Text bulletLeftText;
    private int _weaponChamblerMax;
    private void Start()
    {
        _weaponChamblerMax = weapon.weaponChambler;
        bulletLeftText.text = weapon.weaponChambler.ToString();
    }
    public void BulletCounter()
    {
        
        weapon.weaponChambler--;
        bulletLeftText.text = weapon.weaponChambler.ToString();
        if (weapon.weaponChambler < 0)
        {
            weapon.weaponChambler = _weaponChamblerMax;
            bulletLeftText.text = weapon.weaponChambler.ToString();
            Debug.Log("Reload");
        }
        

        
    }
}
