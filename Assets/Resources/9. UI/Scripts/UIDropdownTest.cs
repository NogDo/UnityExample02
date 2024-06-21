using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDropdownTest : MonoBehaviour
{
    #region private º¯¼ö
    private Dropdown dropdown;

    private char charTemp = 'E';
    #endregion

    void Awake()
    {
        dropdown = GetComponent<Dropdown>();
    }

    public void OnDropdownValueChange(int value)
    {
        print($"{dropdown.options[value].text} selected.");
    }

    public void OnAddOptionButtonClick()
    {
        charTemp++;
        string optionName = $"Option {charTemp}";

        Dropdown.OptionData optionData = new Dropdown.OptionData();
        optionData.text = optionName;

        dropdown.options.Add(optionData);
    }
}
