using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class CItemInfo : MonoBehaviour
{
    #region public 변수
    public List<ItemInformation> itemList;
    public List<Sprite> itemSpriteList;
    #endregion

    #region private 변수
    List<ItemInformation> showItemList;
    #endregion

    /// <summary>
    /// 아이템 정보 리스트
    /// </summary>
    public List<ItemInformation> Item
    {
        get
        {
            return showItemList;
        }
    }

    /// <summary>
    /// 보여줄 아이템 리스트 개수
    /// </summary>
    public int Count
    {
        get
        {
            return showItemList.Count;
        }
    }

    /// <summary>
    /// 아이템 정보 JSON파일로 저장
    /// </summary>
    public void SaveItemInformation()
    {
        string path = $"{Application.streamingAssetsPath}/ItemInformation.json";
        string json = JsonConvert.SerializeObject(itemList);

        File.WriteAllText(path, json);
    }

    /// <summary>
    /// JSON으로 저장된 아이템 정보를 List에 할당
    /// </summary>
    public void LoadItemInformation()
    {
        DirectoryInfo di = new DirectoryInfo(Application.streamingAssetsPath);

        FileInfo[] file = di.GetFiles("ItemInformation.json");
        string json = File.ReadAllText(file[0].FullName);

        showItemList = JsonConvert.DeserializeObject<List<ItemInformation>>(json);
    }
}

/// <summary>
/// 아이템 정보가 담긴 클래스
/// </summary>
[System.Serializable]
public class ItemInformation
{
    public EItemType[] m_eItemType;
    public string m_strName;
    public float m_fAttack;
    public float m_fDeffence;
    public int m_nCost;
    public int m_nItemIndex;
}