using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerEquip : MonoBehaviour
{
    #region public 변수
    public Transform[] hands;
    #endregion

    #region private 변수
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
        
        // 착용하고 있던 아이템이 존재할 경우
        if (weaponObjects[index] != null)
        {
            Destroy(weaponObjects[index]);
            weaponObjects[index] = null;
        }

        // 매개변수 waepon이 null이 아니면 무기 오브젝트를 생성한다.
        if (weapon != null)
        {
            weaponObjects[index] = Instantiate(weapon.equipPrefab, hands[index]);
        }
    }
}