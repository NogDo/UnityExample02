using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEasyToggleTest : MonoBehaviour
{
    #region public ����
    public Image targetImage;
    public Color changeColor;
    #endregion

    /// <summary>
    /// Toggle�� on Value Change �̺�Ʈ�� ȣ�� �� �޼���
    /// </summary>
    /// <param name="isOn"></param>
    public void OnToggleValueChange(bool isOn)
    {
        if (isOn)
        {
            targetImage.color = changeColor;

            print($"{name} toggle is on");
        }

        else
        {
            print($"{name} toggle is off");
        }
    }
}
