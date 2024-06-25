using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICoolTimeImageControl : MonoBehaviour
{
    #region public 변수
    public UISkillEquipSlot skillEquipSlot;
    #endregion

    #region private 변수
    Image cooltimeImage;

    IEnumerator imageCoolTimeCoroutine;
    IEnumerator decreaseImageAmountCoroutine;

    float fCooltime;
    #endregion

    void OnEnable()
    {
        cooltimeImage = GetComponent<Image>();

        fCooltime = skillEquipSlot.Skill.fCooltime;

        imageCoolTimeCoroutine = ImageCoolTime();
        StartCoroutine(imageCoolTimeCoroutine);
    }

    void OnDisable()
    {
        StopCoroutine(imageCoolTimeCoroutine);
    }

    /// <summary>
    /// 스킬의 쿨타임 마다 한번씩 Image의 fillAmount값을 줄이는 코루틴을 실행하는 코루틴
    /// </summary>
    /// <returns></returns>
    IEnumerator ImageCoolTime()
    {
        while (true)
        {
            cooltimeImage.fillAmount = 1.0f;

            decreaseImageAmountCoroutine = DecreaseAmount();
            StartCoroutine(decreaseImageAmountCoroutine);

            yield return new WaitForSeconds(fCooltime);

            StopCoroutine(decreaseImageAmountCoroutine);
        }
    }

    /// <summary>
    /// Image의 fillAmount를 시간에 따라 점차 줄이는 코루틴
    /// </summary>
    /// <returns></returns>
    IEnumerator DecreaseAmount()
    {
        float fNowCooltime = fCooltime;

        while (fNowCooltime > 0)
        {
            cooltimeImage.fillAmount = fNowCooltime / fCooltime;
            fNowCooltime -= Time.deltaTime;

            yield return null;
        }

        cooltimeImage.fillAmount = 0;
    }
}
