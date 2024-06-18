using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class CFillItemInfo : MonoBehaviour
{
    #region private 변수
    CItemInfo itemInfo;
    #endregion

    void Awake()
    {
        itemInfo = FindObjectOfType<CItemInfo>();
    }

    void OnEnable()
    {
        itemInfo.LoadItemInformation();

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = itemInfo.itemSpriteList[i];
            transform.GetChild(i).GetChild(1).GetComponent<Text>().text = itemInfo.Item[i].m_strName;
            transform.GetChild(i).GetChild(2).GetComponent<Text>().text = $"공격력 : {itemInfo.Item[i].m_fAttack}";
            transform.GetChild(i).GetChild(3).GetComponent<Text>().text = $"방어력 : {itemInfo.Item[i].m_fDeffence}";
            transform.GetChild(i).GetChild(4).GetComponent<Text>().text = $"가격 : {itemInfo.Item[i].m_nCost}";
        }
    }
}