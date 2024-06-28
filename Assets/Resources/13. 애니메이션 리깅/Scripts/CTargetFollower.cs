using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTargetFollower : MonoBehaviour
{
    #region public º¯¼ö
    public Transform target;
    #endregion

    void Update()
    {
        if (target is not null)
        {
            transform.position = target.position;
            transform.rotation = target.rotation;
        }
    }
}