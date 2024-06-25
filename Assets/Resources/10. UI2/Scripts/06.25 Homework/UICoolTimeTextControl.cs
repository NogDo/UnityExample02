using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICoolTimeTextControl : MonoBehaviour
{
    #region public 변수
    public UISkillEquipSlot skillEquipSlot;
    #endregion

    #region private 변수
    TextMeshProUGUI cooltimeText;

    IEnumerator textCoolTimeCoroutine;
    IEnumerator deceaseTextTimeCoroutine;

    float fCooltime;
    #endregion

    void OnEnable()
    {
        cooltimeText = GetComponent<TextMeshProUGUI>();

        fCooltime = skillEquipSlot.Skill.fCooltime;

        textCoolTimeCoroutine = TextCoolTime();
        StartCoroutine(textCoolTimeCoroutine);
    }

    void OnDisable()
    {
        StopCoroutine(textCoolTimeCoroutine);
    }

    /// <summary>
    /// 스킬의 쿨타임 마다 한번씩 Text를 시간에 따라 바꾸는 코루틴을 실행하는 코루틴
    /// </summary>
    /// <returns></returns>
    IEnumerator TextCoolTime()
    {
        while (true)
        {
            cooltimeText.text = fCooltime.ToString();

            deceaseTextTimeCoroutine = DecreaseTextTime();
            StartCoroutine(deceaseTextTimeCoroutine);

            yield return new WaitForSeconds(fCooltime);

            StopCoroutine(deceaseTextTimeCoroutine);
        }
    }

    /// <summary>
    /// Text를 남은 시간으로 바꾸는 코루틴
    /// </summary>
    /// <returns></returns>
    IEnumerator DecreaseTextTime()
    {
        float fNowCooltime = fCooltime;

        while (fNowCooltime > 0)
        {
            cooltimeText.text = fNowCooltime.ToString("F1");
            fNowCooltime -= Time.deltaTime;

            yield return null;
        }

        cooltimeText.text = "0";
    }
}
