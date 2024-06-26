using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPoolTest : MonoBehaviour
{
    #region public ����
    public CObjectPool pool;
    #endregion

    void Awake()
    {
        if (pool is null)
        {
            pool = GetComponent<CObjectPool>();
        }
    }

    public void SpawnSphere()
    {
        GameObject obj = pool.GetObject();
        // Random.insideUnitSphere : Vecotr3�� ��ȯ�Ǵ� ������Ƽ�̴�. xyz ���� ��� -1 ~ 1 �����̴�.
        obj.transform.position = Random.insideUnitSphere * 5;

        StartCoroutine(DespawnCoroutine(obj));
    }

    IEnumerator DespawnCoroutine(GameObject obj)
    {
        yield return new WaitForSeconds(Random.Range(2.0f, 5.0f));

        pool.ReturnObject(obj);
    }
}