using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoCurrentText;
    [SerializeField] private TextMeshProUGUI ammoLeftText;
    public void SetText(TextFieldKeys textFieldKey, string textToSet)
    {
        switch (textFieldKey)
        {
            case TextFieldKeys.AmmoCurrentText:
                ammoCurrentText.text = textToSet;
                break;
            case TextFieldKeys.AmmoLeftText:
                ammoLeftText.text = textToSet;
                break;
            
        }
    }
    public enum TextFieldKeys
    {
        AmmoCurrentText,
        AmmoLeftText
    }
}
