using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISkillEquipSlot : UISkillInvetorySlot
{
    #region public ����

    #endregion

    public override Skill0625 Skill
    {
        get => base.Skill;

        set
        {


            base.Skill = value;
        }
    }


}