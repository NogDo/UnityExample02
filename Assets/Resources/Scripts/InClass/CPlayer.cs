using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer : MonoBehaviour, IHitable
{
    #region public 변수
    public CBullet oBulletPrefab;
    public Transform shotPoint;

    public float fDamage = 10.0f;
    public float fMaxHP = 100.0f;
    public float fCurrentHP = 100.0f;
    #endregion

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Debug.Log($"{gameObject.name} press button");

            Shot();
        }
    }

    public void Hit(float damage)
    {
        fCurrentHP -= damage;

        print($"Player take damage : {damage}, current HP : {fCurrentHP}");
    }

    public void Shot()
    {
        CBullet bullet = Instantiate(oBulletPrefab, shotPoint.position, shotPoint.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 10.0f, ForceMode.Impulse);
        bullet.fDamage = fDamage;

        // bullet에게 맞아야 할 대상의 Layer를 지정
        bullet.targetLayer = (1 << LayerMask.NameToLayer("BoxLayer")) + (1 << LayerMask.NameToLayer("Monster"));

        Destroy(bullet, 3.0f);
    }
}
