using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CEquipSlot : CInventorySlot
{
    #region public ����
    public Image defaultIconImage;
    public CPlayerEquip playerEquip;
    public int handIndex;
    #endregion

    // Set Item�� �Ҷ�
    // item propertie�� ���� ������ ���� ������ ����
    public override ItemInClass0625 Item
    {
        get => base.Item;

        set
        {
            // �������� �������� �������� Ȯ��
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
