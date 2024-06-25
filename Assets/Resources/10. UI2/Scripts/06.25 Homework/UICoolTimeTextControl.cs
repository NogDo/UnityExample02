using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICoolTimeTextControl : MonoBehaviour
{
    #region public ����
    public UISkillEquipSlot skillEquipSlot;
    #endregion

    #region private ����
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
    /// ��ų�� ��Ÿ�� ���� �ѹ��� Text�� �ð��� ���� �ٲٴ� �ڷ�ƾ�� �����ϴ� �ڷ�ƾ
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
    /// Text�� ���� �ð����� �ٲٴ� �ڷ�ƾ
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
