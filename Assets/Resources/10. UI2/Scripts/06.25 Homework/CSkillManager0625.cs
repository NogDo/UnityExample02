using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 스킬 정보를 가지고 있는 클래스
/// </summary>
[System.Serializable]
public class Skill0625
{
    #region public 변수
    public Sprite skillIcon;
    public float fCooltime;
    #endregion
}

public class CSkillManager0625 : MonoBehaviour
{
    #region public 변수
    public static CSkillManager0625 Instance { get; private set; }

    public List<Skill0625> skillList;
    public RectTransform oSkillInventoryContent;
    public RectTransform skillPage;

    public UISkillInvetorySlot focusedSlot;
    #endregion

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        for (int i = 0; i < skillList.Count; i++)
        {
            oSkillInventoryContent.GetChild(i).GetComponent<UISkillInvetorySlot>().Skill = skillList[i];
        }
    }
}