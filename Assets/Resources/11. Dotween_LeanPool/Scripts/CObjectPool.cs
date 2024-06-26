using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CObjectPool : MonoBehaviour
{
    #region public 변수
    public GameObject prefab;

    public int startCount = 10;
    #endregion

    #region private 변수
    Queue<GameObject> pool = new Queue<GameObject>();
    #endregion

    void Start()
    {
        for (int i = 0; i < startCount; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);

            pool.Enqueue(obj);
        }
    }

    public GameObject GetObject()
    {
        if (pool.Count == 0)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);

            pool.Enqueue(obj);
        }

        GameObject @return = pool.Dequeue();
        @return.SetActive(true);
        @return.transform.SetParent(null);

        return @return;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(transform);

        pool.Enqueue(obj);
    }
}