using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CSphere : MonoBehaviour
{
    void OnEnable()
    {
        transform.DOComplete();
        transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.5f);
    }
}