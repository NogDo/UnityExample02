using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICurrencyList : MonoBehaviour
{
    #region public ����
    // Scrollview List ���� Transform
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