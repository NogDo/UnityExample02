using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerEquip : MonoBehaviour
{
    #region public ����
    public Transform[] hands;
    #endregion

    #region private ����
    WeaponInClass0625[] weapons = new WeaponInClass0625[2];
    GameObject[] weaponObjects = new GameObject[2];
    #endregion

    public void EquipWeapon(int index, WeaponInClass0625 weapon)
    {
        if (index >= weapons.Length)
        {
            return;
        }

        weapons[index] = weapon;
        
        // �����ϰ� �ִ� �������� ������ ���
        if (weaponObjects[index] != null)
        {
            Destroy(weaponObjects[index]);
            weaponObjects[index] = null;
        }

        // �Ű����� waepon�� null�� �ƴϸ� ���� ������Ʈ�� �����Ѵ�.
        if (weapon != null)
        {
            weaponObjects[index] = Instantiate(weapon.equipPrefab, hands[index]);
        }
    }
}