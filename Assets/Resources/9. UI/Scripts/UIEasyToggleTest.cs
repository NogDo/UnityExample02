using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEasyToggleTest : MonoBehaviour
{
    #region public 변수
    public Image targetImage;
    public Color changeColor;
    #endregion

    /// <summary>
    /// Toggle이 on Value Change 이벤트로 호출 할 메서드
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
