using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CPostProcessingTest : MonoBehaviour
{
    #region public ����
    public PostProcessVolume volume;

    [Range(0.0f, 1.0f)]
    public float caIntencity = 0.0f;
    #endregion

    #region private ����
    ChromaticAberration ca;
    #endregion

    void Start()
    {
        if (volume.profile.TryGetSettings(out ca))
        {
            print("�� ���� ���� ������");
        }
        
        else
        {
            print("�� ���� ���� ���� ����");
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