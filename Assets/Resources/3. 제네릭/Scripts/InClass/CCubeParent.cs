using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCubeParent : MonoBehaviour
{
    #region private 변수
    private Transform[] cubes;
    #endregion

    #region public 변수
    public Color[] colors;
    public int[] xPosition;
    public float[] scales;
    #endregion

    void Awake()
    {
        cubes = new Transform[transform.childCount];

        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i] = transform.GetChild(i);
        }
    }

    void Start()
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].GetComponent<Renderer>().material.color = colors[i];

            Vector3 localPosition = cubes[i].localPosition;
            localPosition.x = xPosition[i];
            cubes[i].localPosition = localPosition;

            cubes[i].localScale = Vector3.one * scales[i];
        }
    }
}
