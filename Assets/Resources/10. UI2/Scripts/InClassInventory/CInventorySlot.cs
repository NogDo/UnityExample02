using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#region ����Ƽ �̺�Ʈ �ڵ鷯 �������̽�
/*
 
- ȣ�� ��ü : EventSystem (Canvas ���� �� �ڵ����� ���̾��Űâ�� �����Ǵ� ��)
 
*/
#endregion

public class CInventorySlot : MonoBehaviour,
    IDragHandler, IBeginDragHandler, IEndDragHandler,
    IPointerEnterHandler, IPointerExitHandler
{
    #region public ����
    public Image iconImage;
    // internal ���� ������ : ������ Assembly(���� project)���� �ִ� �ٸ� Ÿ�Ե��� �׼��� �� �� �ִ�. ������ �ٸ� Assembly������ ������ �Ұ��ϴ�.
    // ����Ƽ������ Inspector���� ������ �ȵǴ� ��� �ٸ� ��ũ��Ʈ������ ������ ����
    // ������Ÿ���� �� ���� ������ �ʿ��� �� HideInInspector ��Ʈ����Ʈ�� ��ü�Ͽ� Ȱ��
    internal ItemInClass0625 item = null;
    #endregion

    /// <summary>
    /// ItemSlot�� Item ���� ���� Ȯ��
    /// </summary>
    public bool HasItem
    {
        get
        {
            return item != null;
        }
    }

    public virtual ItemInClass0625 Item
    {
        get
        {
            return item;
        }

        set
        {
            item = value;

            if (item == null)
            {
                iconImage.enabled = false;
            }

            else
            {
                iconImage.enabled = true;
                iconImage.sprite = item.iconSprite;
            }
        }
    }

    void Start()
    {
        Item = item;
    }

    public virtual bool TrySwap(ItemInClass0625 item)
    {
        if (item is WeaponInClass0625 && HasItem)
        {
            if (this.item is WeaponInClass0625)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        return true;
    }

    public void OnBeginDrag(PointerEventData data)
    {
        // �������� ���ؼ� ! ������ ��� false == �� ���⵵ �Ѵ�.
        if (false == HasItem)
        {
            return;
        }

        // �θ� ����. null�� �Ҵ�� ��� �θ� ���� �ֻ�� ������Ʈ�� ��.
        iconImage.rectTransform.SetParent(CInventoryManagerInClass0625.Instace.equipPage);

        // �巡�װ� ������ �� InvetoryManager�� ���� ������ ���ý������� ����
        CInventoryManagerInClass0625.Instace.selectedSlot = this;
    }

    public void OnDrag(PointerEventData data)
    {
        if (false == HasItem)
        {
            return;
        }

        // RectTransfor.position : ��ũ�� �󿡼��� ��ġ
        iconImage.rectTransform.position = data.position;
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (false == HasItem)
        {
            return;
        }

        // ��ȿ�� �巡�� �Ǵ�
        if (CInventoryManagerInClass0625.Instace.focusedSlot != this && CInventoryManagerInClass0625.Instace.focusedSlot != null)
        {
            CInventorySlot targetSlot = CInventoryManagerInClass0625.Instace.focusedSlot;

            if (targetSlot.TrySwap(item))
            {
                ItemInClass0625 tempItem = targetSlot.Item;

                targetSlot.Item = item;
                this.Item = tempItem;
            }
        }

        CInventoryManagerInClass0625.Instace.selectedSlot = null;

        iconImage.rectTransform.SetParent(transform);
        // anchoredPoistion : ��Ŀ�κ����� ����� ��ġ
        iconImage.rectTransform.anchoredPosition = Vector2.zero;
    }

    public void OnPointerEnter(PointerEventData data)
    {
        CInventoryManagerInClass0625.Instace.focusedSlot = this;
    }

    public void OnPointerExit(PointerEventData data)
    {
        CInventoryManagerInClass0625.Instace.focusedSlot = null;
    }
}