using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CExcelItemInfo : MonoBehaviour
{
    #region public ����
    public ItemInfo itemInfoList;
    #endregion

    void Start()
    {
        print("���� �ҷ����� �׽�Ʈ");

        foreach (ExcelItemInfo item in itemInfoList.Sheet1)
        {
            print($"�̸� : {item.name}");
            print($"���ݷ� : {item.attack}");
            print($"���� : {item.deffence}");
            print($"���� : {item.cost}");
            print("--------------------");
        }
    }

}

/// <summary>
/// ���� ������ ����
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