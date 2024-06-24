using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIItemElement : MonoBehaviour
{
    #region public ����
    public Image iconImage;
    public TextMeshProUGUI countText;
    #endregion

    #region private ����
    ItemData data;
    #endregion

    public void SetData(ItemData data)
    {
        this.data = data;

        iconImage.sprite = data.iconSprite;
        countText.text = data.nCount.ToString();

        iconImage.gameObject.SetActive(true);
        countText.gameObject.SetActive(true);
    }
}