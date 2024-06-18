using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CExcelItemInfo : MonoBehaviour
{
    #region public 변수
    public ItemInfo itemInfoList;
    #endregion

    void Start()
    {
        print("엑셀 불러오기 테스트");

        foreach (ExcelItemInfo item in itemInfoList.Sheet1)
        {
            print($"이름 : {item.name}");
            print($"공격력 : {item.attack}");
            print($"방어력 : {item.deffence}");
            print($"가격 : {item.cost}");
            print("--------------------");
        }
    }

}

/// <summary>
/// 엑셀 아이템 정보
/// </summary>
[System.Serializable]
public class ExcelItemInfo
{
    public int id;
    public string name;
    public float attack;
    public float deffence;
    public int cost;
}