using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData
{
    #region public ����
    public Sprite iconSprite;
    public int nCount;
    #endregion
}

[CreateAssetMenu]
public class InventoryData : ScriptableObject
{
    #region public ����
    public List<ItemData> itemList;
    #endregion
}
