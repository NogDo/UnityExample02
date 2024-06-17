using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDayNightManager : MonoBehaviour
{
    #region public ����
    public static CDayNightManager Instance { get; private set; }

    public Transform lightTransform;

    // observer Pattern�� �κ������� ����
    // ����Ƽ���� ������ ���� ������ delegate �Ǵ� eventHandler�� �ַ� Ȱ��
    public Action<bool> onDayComesUp;
    #endregion

    #region private ����
    private bool isDay = true;
    #endregion

    void Awake()
    {
        Instance = this;
        onDayComesUp = 
            (isDay) => 
        { 
            lightTransform.eulerAngles = new Vector3(isDay ? 30 : 190, 0, 0); 
        };
    }

    public void DayToggleButtonClick()
    {
        isDay = !isDay;

        onDayComesUp?.Invoke(isDay);
    }
}
