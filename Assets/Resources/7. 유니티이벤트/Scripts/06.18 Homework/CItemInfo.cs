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

    public List<ItemInformation> Item
    {
        get
        {
            return showItemList;
        }
    }

    public int Count
    {
        get
        {
            return showItemList.Count;
        }
    }

    public void SaveItemInformation()
    {
        string path = $"{Application.streamingAssetsPath}/ItemInformation.json";
        string json = JsonConvert.SerializeObject(itemList);

        File.WriteAllText(path, json);
    }

    public void LoadItemInformation()
    {
        DirectoryInfo di = new DirectoryInfo(Application.streamingAssetsPath);

        FileInfo[] file = di.GetFiles("ItemInformation.json");
        string json = File.ReadAllText(file[0].FullName);

        showItemList = JsonConvert.DeserializeObject<List<ItemInformation>>(json);
    }
}

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