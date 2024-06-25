using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICoolTimeImageControl : MonoBehaviour
{
    #region public ����
    public UISkillEquipSlot skillEquipSlot;
    #endregion

    #region private ����
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
    /// ��ų�� ��Ÿ�� ���� �ѹ��� Image�� fillAmount���� ���̴� �ڷ�ƾ�� �����ϴ� �ڷ�ƾ
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
    /// Image�� fillAmount�� �ð��� ���� ���� ���̴� �ڷ�ƾ
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
