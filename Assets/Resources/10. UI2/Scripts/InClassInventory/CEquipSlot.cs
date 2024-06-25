using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CEquipSlot : CInventorySlot
{
    #region public 변수
    public Image defaultIconImage;
    public CPlayerEquip playerEquip;
    public int handIndex;
    #endregion

    // Set Item을 할때
    // item propertie에 값을 대입할 때의 로직을 수정
    public override ItemInClass0625 Item
    {
        get => base.Item;

        set
        {
            // 넣으려는 아이템이 무기인지 확인
            if (value is WeaponInClass0625)
            {
                playerEquip.EquipWeapon(handIndex, value as WeaponInClass0625);
                defaultIconImage.enabled = false;
                base.Item = value;
            }

            else if (value == null)
            {
                playerEquip.EquipWeapon(handIndex, null);
                defaultIconImage.enabled = true;
                base.Item = value;
            }
        }
    }

    public override bool TrySwap(ItemInClass0625 item)
    {
        if (item is WeaponInClass0625 || item is null)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
