using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBox : MonoBehaviour, IHitable
{
    #region public º¯¼ö
    public float fMaxDamage = 10.0f;
    public LayerMask someLayer;
    #endregion

    void Start()
    {
        print(someLayer.value);

        Ray ray = new Ray(Vector3.zero, Vector3.up);
        Physics.Raycast(ray, Mathf.Infinity, someLayer);
    }

    public void Hit(float damage)
    {
        if (damage >= fMaxDamage)
        {
            Destroy(gameObject);
        }

        print($"{name} hit and damage : {damage}");
    }
}
