using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어 데이터를 참조하는 클래스
/// </summary>
public class PlayerData
{
    #region private 변수
    // Enum.GetValues : 열거형 타입 내의 요소 전부를 가져오는 함수
    private int[] currencyArray = new int[Enum.GetValues(typeof(ECurrencyType)).Length];

    public int this[ECurrencyType type]
    {
        get
        {
            return currencyArray[(int)type];
        }

        set
        {
            currencyArray[(int)type] = value;
        }
    }
    #endregion
}

public class CDataManager : MonoBehaviour
{
    #region public 변수
    public static CDataManager Instance { get; private set; }

    public List<CurrencyData> currencyDataList;
    public UICurrencyList currencyList;
    public PlayerData playerData = new PlayerData();
    public Action<ECurrencyType, int> onCurrencyAmountChange;
    #endregion

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currencyList.Initialize();
    }

    public void AddCurrency(int param)
    {
        ECurrencyType currencyType = (ECurrencyType)param;

        playerData[currencyType]++;

        onCurrencyAmountChange?.Invoke(currencyType, playerData[currencyType]);

        print($"{currencyType} 상승 : {playerData[currencyType]}");
    }
}
