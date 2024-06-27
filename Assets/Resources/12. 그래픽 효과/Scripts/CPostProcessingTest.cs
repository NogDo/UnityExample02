using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CPostProcessingTest : MonoBehaviour
{
    #region public 변수
    public PostProcessVolume volume;

    [Range(0.0f, 1.0f)]
    public float caIntencity = 0.0f;
    #endregion

    #region private 변수
    ChromaticAberration ca;
    #endregion

    void Start()
    {
        if (volume.profile.TryGetSettings(out ca))
        {
            print("색 수차 세팅 존재함");
        }
        
        else
        {
            print("색 수차 세팅 참조 실패");
        }
    }

    void Update()
    {
        if (ca == null)
        {
            return;
        }

        ca.intensity.value = caIntencity;
    }
}