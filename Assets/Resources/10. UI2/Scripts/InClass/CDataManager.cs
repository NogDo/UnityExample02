using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾� �����͸� �����ϴ� Ŭ����
/// </summary>
public class PlayerData
{
    #region private ����
    // Enum.GetValues : ������ Ÿ�� ���� ��� ���θ� �������� �Լ�
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
    #region public ����
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

        print($"{currencyType} ��� : {playerData[currencyType]}");
    }
}
