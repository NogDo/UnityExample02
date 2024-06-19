using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CShaderTest : MonoBehaviour
{
    #region private ����
    Renderer render;
    #endregion

    #region public ����
    [Range(0, 1)]
    public float colorAmount;
    #endregion

    void Awake()
    {
        render = GetComponent<Renderer>();
    }

    void Update()
    {
        render.material.SetFloat("_colorAmount", colorAmount);
        //render.material.SetColor("_MainTex", Color.white);
    }
}