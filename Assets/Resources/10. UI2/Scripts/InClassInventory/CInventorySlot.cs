using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#region 유니티 이벤트 핸들러 인터페이스
/*
 
- 호출 주체 : EventSystem (Canvas 생성 시 자동으로 하이어라키창에 생성되는 것)
 
*/
#endregion

public class CInventorySlot : MonoBehaviour,
    IDragHandler, IBeginDragHandler, IEndDragHandler,
    IPointerEnterHandler, IPointerExitHandler
{
    #region public 변수
    public Image iconImage;
    // internal 접근 지정자 : 동일한 Assembly(같은 project)내에 있는 다른 타입들이 액세스 할 수 있다. 하지만 다른 Assembly에서는 접근이 불가하다.
    // 유니티에서는 Inspector에서 참조가 안되는 대신 다른 스크립트에서는 접근이 가능
    // 프로토타입핑 등 빠른 구현이 필요할 때 HideInInspector 어트리뷰트를 대체하여 활용
    internal ItemInClass0625 item = null;
    #endregion

    /// <summary>
    /// ItemSlot에 Item 존재 여부 확인
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
        // 가독성을 위해서 ! 연산자 대신 false == 를 쓰기도 한다.
        if (false == HasItem)
        {
            return;
        }

        // 부모 지정. null이 할당될 경우 부모가 없는 최상단 오브젝트가 됨.
        iconImage.rectTransform.SetParent(CInventoryManagerInClass0625.Instace.equipPage);

        // 드래그가 시작할 때 InvetoryManager에 시작 슬롯을 선택슬롯으로 저장
        CInventoryManagerInClass0625.Instace.selectedSlot = this;
    }

    public void OnDrag(PointerEventData data)
    {
        if (false == HasItem)
        {
            return;
        }

        // RectTransfor.position : 스크린 상에서의 위치
        iconImage.rectTransform.position = data.position;
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (false == HasItem)
        {
            return;
        }

        // 유효란 드래그 판단
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
        // anchoredPoistion : 앵커로부터의 상대적 위치
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