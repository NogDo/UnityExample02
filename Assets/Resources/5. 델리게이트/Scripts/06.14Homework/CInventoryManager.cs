using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CInventoryManager : MonoBehaviour
{
    #region public ����
    public GameObject[] prefabItem;
    #endregion

    #region private ����
    List<GameObject> inventory;
    #endregion

    void Awake()
    {
        inventory = new List<GameObject>();
    }

    /// <summary>
    /// �������� �κ��丮�� �߰��Ѵ�.
    /// </summary>
    /// <param name="index">������ �߰� ��ư index</param>
    public void AddItem(int index)
    {
        GameObject item = Instantiate(prefabItem[index], transform);

        inventory.Add(item);
    }

    /// <summary>
    /// ������ ������ ������ ������ 1�� ���δ�.
    /// </summary>
    /// <param name="index">������ ���� ��ư index</param>
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
    /// �������� �κ��丮���� �����Ѵ�.
    /// </summary>
    /// <param name="item">������</param>
    public void RemoveItem(GameObject item)
    {
        inventory.Remove(item);
    }
}
