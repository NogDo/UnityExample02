using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMonster : MonoBehaviour, IHitable
{
    #region public º¯¼ö
    public string monsterName;
    public float maxHP;
    public float currentHP;
    public float fDamage;
    public float fShotInterval = 1.0f;

    public GameObject oBulletPrefab;
    public Transform shotPoint;
    #endregion

    void Start()
    {
        StartCoroutine(ShotCoroutine());
    }

    public virtual void Hit(float damage)
    {
        currentHP -= damage;
        print($"{monsterName} take damage : {damage}, current HP : {currentHP}");
    }

    IEnumerator ShotCoroutine()
    {
        if (oBulletPrefab == null || shotPoint == null)
        {
            yield break;
        }

        while (true)
        {
            Shot();
            yield return new WaitForSeconds(fShotInterval);
        }
    }

    public void Shot()
    {
        GameObject bulletObject = Instantiate(oBulletPrefab, shotPoint.position, shotPoint.rotation);
        bulletObject.GetComponent<Rigidbody>().AddForce(bulletObject.transform.forward * 10.0f, ForceMode.Impulse);

        CBullet bullet = bulletObject.GetComponent<CBullet>();
        bullet.fDamage = fDamage;
        bullet.targetLayer = 1 << LayerMask.NameToLayer("Player");

        Destroy(bulletObject, 3.0f);
    }
}