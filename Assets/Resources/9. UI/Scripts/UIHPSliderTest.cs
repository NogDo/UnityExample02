using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHPSliderTest : MonoBehaviour
{
    #region public ����
    public float hp;
    #endregion

    #region private ����
    private Slider slider;
    #endregion

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Start()
    {
        slider.minValue = 0;
        slider.maxValue = hp;
        slider.value = hp;
    }

    public void OnDamageButtonClick(float damage)
    {
        hp -= damage;
        slider.value = hp;
    }
}
