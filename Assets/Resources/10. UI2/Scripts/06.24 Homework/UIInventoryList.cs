using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryList : MonoBehaviour
{
    public void Load()
    {
        int index = 0;

        foreach (ItemData data in CInventoryManager0624.Instance.inventoryData.itemList)
        {
            transform.GetChild(index).GetComponent<UIItemElement>().SetData(data);
            index++;
        }
    }
}