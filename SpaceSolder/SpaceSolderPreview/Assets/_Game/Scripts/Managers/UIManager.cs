using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoCurrentText;
    [SerializeField] private TextMeshProUGUI ammoLeftText;
    [SerializeField] private PointerListener pointerListener;
    [SerializeField] private Button throwButton;
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

    public enum ButtonTypes
    {
        ButtonFire,
        ButtonFireStop,
        ButtonThrow
    }

    public void SubscribeOn(ButtonTypes buttonTypes, Action onClickCallback)
    {
        switch (buttonTypes)
        {
            case ButtonTypes.ButtonFire:
                pointerListener.OnPointerDown += onClickCallback;
                break;
            case ButtonTypes.ButtonFireStop:
                pointerListener.OnPointerUp += onClickCallback;
                break;
            case ButtonTypes.ButtonThrow:
                throwButton.onClick.AddListener(new UnityAction(onClickCallback));
                break;
        }
    }

    public void RemoveListener(ButtonTypes buttonTypes, Action onClickCallback)
    {
        switch (buttonTypes)
        {
            case ButtonTypes.ButtonFire:
                pointerListener.OnPointerDown -= onClickCallback;
                break;
            case ButtonTypes.ButtonFireStop:
                pointerListener.OnPointerUp -= onClickCallback;
                break;
        }
    }

    public void SetActiveButton(ButtonTypes buttonTypes, bool isActive)
    {
        switch (buttonTypes)
        {
            case ButtonTypes.ButtonFire:
                break;
            case ButtonTypes.ButtonFireStop:
                break;
            case ButtonTypes.ButtonThrow:
                throwButton.gameObject.SetActive(isActive);
                break;
        }
    }
}
