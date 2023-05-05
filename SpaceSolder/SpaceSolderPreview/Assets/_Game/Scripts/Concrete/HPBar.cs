using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private BaseDamageReceiver baseDamageReceiver;
    void Start()
    {
        healthSlider.maxValue = baseDamageReceiver.HP;
    }

    void Update()
    {
        healthSlider.value = baseDamageReceiver.HP;
    }
}
