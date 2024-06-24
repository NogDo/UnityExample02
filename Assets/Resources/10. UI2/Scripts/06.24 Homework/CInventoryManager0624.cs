using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInventoryManager0624 : MonoBehaviour
{
    #region public º¯¼ö
    public static CInventoryManager0624 Instance { get; private set; }

    public InventoryData inventoryData;
    public UIInventoryList inventoryList;
    #endregion

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        inventoryList.Load();
    }
}