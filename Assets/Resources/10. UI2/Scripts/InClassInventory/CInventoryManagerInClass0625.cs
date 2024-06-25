using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInventoryManagerInClass0625 : MonoBehaviour
{
    #region public 변수
    public static CInventoryManagerInClass0625 Instace { get; private set; }

    public RectTransform equipPage;
    public RectTransform inventoryContent;

    public int inventorySlotCount;
    public CInventorySlot inventorySlotPrefab;

    [Space(20)]
    public CInventorySlot focusedSlot;
    public CInventorySlot selectedSlot;

    public List<WeaponInClass0625> tempWeapons;
    public List<ItemInClass0625> tempItems;
    #endregion

    #region private 변수
    List<CInventorySlot> inventorySlots = new();
    #endregion

    void Awake()
    {
        Instace = this;
    }

    void Start()
    {
        tempItems.InsertRange(0, tempWeapons);

        for (int i = 0; i < tempItems.Count; i++)
        {
            inventoryContent.GetChild(i).GetComponent<CInventorySlot>().Item = tempItems[i];
        }
    }
}

[System.Serializable]
public class ItemInClass0625
{
    public Sprite iconSprite;
    public string name;
    public string desc;
}

[System.Serializable]
public class WeaponInClass0625 : ItemInClass0625
{
    public float damage;
    public GameObject equipPrefab;
}
