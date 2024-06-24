using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICurrencyList : MonoBehaviour
{
    #region public 변수
    // Scrollview List 내부 Transform
    public Transform content;
    public UICurrencyElement CurrencyElementPrefab;
    #endregion

    public void Initialize()
    {
        foreach (CurrencyData data in CDataManager.Instance.currencyDataList)
        {
            Instantiate(CurrencyElementPrefab, content).SetData(data);
        }
    }
}