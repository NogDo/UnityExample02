using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDayNightManager : MonoBehaviour
{
    #region public 변수
    public static CDayNightManager Instance { get; private set; }

    public Transform lightTransform;

    // observer Pattern을 부분적으로 구현
    // 유니티에서 옵저버 패턴 구현시 delegate 또는 eventHandler를 주로 활용
    public Action<bool> onDayComesUp;
    #endregion

    #region private 변수
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
