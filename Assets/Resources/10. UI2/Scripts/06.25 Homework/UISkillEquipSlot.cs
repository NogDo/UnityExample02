using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISkillEquipSlot : UISkillInvetorySlot
{
    #region public º¯¼ö
    public GameObject oSkillCoolTime;
    public GameObject oCoolTimeText;
    #endregion

    public override Skill0625 Skill
    {
        get => base.Skill;

        set
        {
            base.Skill = value;

            if (base.Skill is not null)
            {
                oSkillCoolTime.SetActive(false);
                oCoolTimeText.SetActive(false);

                oSkillCoolTime.SetActive(true);
                oCoolTimeText.SetActive(true);
            }

            else
            {
                oSkillCoolTime.SetActive(false);
                oCoolTimeText.SetActive(false);
            }
        }
    }
}