using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInputfieldTest : MonoBehaviour
{
    #region pivate 변수
    private InputField inputField;
    #endregion

    #region public 변수
    public Text messageText;
    public Text submitText;
    public Text endText;
    #endregion

    void Awake()
    {
        inputField = GetComponent<InputField>();
    }

    public void OnEdit(string text)
    {
        messageText.text = text;
    }

    public void OnSubmit(string text)
    {
        submitText.text = text;
    }

    public void OnEndEdit(string text)
    {
        endText.text = $"<color=red>end edit : {text}</color>";
    }
}
