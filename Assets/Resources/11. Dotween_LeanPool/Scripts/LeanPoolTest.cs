using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class LeanPoolTest : MonoBehaviour
{
    #region public º¯¼ö
    public GameObject prefab;
    #endregion

    public void SpawnSphere()
    {
        GameObject obj = LeanPool.Spawn(prefab, Random.insideUnitSphere * 5, Quaternion.identity);

        LeanPool.Despawn(obj, Random.Range(2.0f, 5.0f));
    }
}