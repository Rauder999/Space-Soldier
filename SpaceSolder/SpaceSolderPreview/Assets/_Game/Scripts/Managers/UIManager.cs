using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System;

public partial class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoCurrentText;
    [SerializeField] private TextMeshProUGUI ammoLeftText;
    [SerializeField] private PointerListener pointerListener;
    [SerializeField] private Button throwButton;
    [SerializeField] private Button useButton;


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
                throwButton.GetComponent<PointerListener>().OnPointerClick += onClickCallback;
                break;
            case ButtonTypes.ButtonUse:
                useButton.GetComponent<PointerListener>().OnPointerClick += onClickCallback;
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

            case ButtonTypes.ButtonThrow:
                throwButton.GetComponent<PointerListener>().OnPointerClick -= onClickCallback;
                break;
            case ButtonTypes.ButtonUse:
                useButton.GetComponent<PointerListener>().OnPointerClick -= onClickCallback;
                break;
        }
    }

    public void SetActiveButton(ButtonTypes buttonTypes, bool isActive)
    {
        switch (buttonTypes)
        {
            case ButtonTypes.ButtonFire:
            case ButtonTypes.ButtonFireStop:
                pointerListener.gameObject.SetActive(isActive);
                break;

            case ButtonTypes.ButtonThrow:
                throwButton.gameObject.SetActive(isActive);
                break;
        }
    }
}
