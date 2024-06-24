using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UICurrencyElement : MonoBehaviour
{
    #region public 변수
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public Slider progressBar;
    public TextMeshProUGUI progressText;
    #endregion

    #region private 변수
    private CurrencyData data;
    #endregion

    /// <summary>
    /// currency element가 생성되고 나서 호출 될 초기화 함수
    /// </summary>
    /// <param name="data">데이터</param>
    public void SetData(CurrencyData data)
    {
        this.data = data;

        iconImage.sprite = data.iconSprite;

        nameText.text = data.currencyName;

        progressBar.minValue = 0;
        progressBar.maxValue = data.maxCount;

        int currentCount = CDataManager.Instance.playerData[data.currencyType];
        progressBar.value = currentCount;

        progressText.text = $"{currentCount} / {data.maxCount}";

        CDataManager.Instance.onCurrencyAmountChange += OnCurrencyAmountChange;
    }

    public void OnCurrencyAmountChange(ECurrencyType type, int count)
    {
        if (type == data.currencyType)
        {
            progressBar.value = count;
            progressText.text = $"{count} / {data.maxCount}";
        }
    }
}
