using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CInventoryManager : MonoBehaviour
{
    #region public 변수
    public GameObject[] prefabItem;
    #endregion

    #region private 변수
    List<GameObject> inventory;
    #endregion

    void Awake()
    {
        inventory = new List<GameObject>();
    }

    /// <summary>
    /// 아이템을 인벤토리에 추가한다.
    /// </summary>
    /// <param name="index">아이템 추가 버튼 index</param>
    public void AddItem(int index)
    {
        GameObject item = Instantiate(prefabItem[index], transform);

        inventory.Add(item);
    }

    /// <summary>
    /// 보여줄 아이템 종류의 투명도를 1로 높인다.
    /// </summary>
    /// <param name="index">아이템 종류 버튼 index</param>
    public void ShowItem(int index)
    {
        if (index == 4)
        {
            foreach (GameObject i in inventory)
            {
                i.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
        }

        else
        {
            foreach (GameObject i in inventory)
            {
                i.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
            }


            List<GameObject> item = inventory.FindAll
                (
                    (paramItem) =>
                    {
                        foreach (EItemType type in paramItem.GetComponent<Item>().itemType)
                        {
                            if (type == (EItemType)index)
                            {
                                return true;
                            }
                        }

                        return false;
                    }
                );

            foreach (GameObject i in item)
            {
                i.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
        }
    }

    /// <summary>
    /// 아이템을 인벤토리에서 삭제한다.
    /// </summary>
    /// <param name="item">아이템</param>
    public void RemoveItem(GameObject item)
    {
        inventory.Remove(item);
    }
}
