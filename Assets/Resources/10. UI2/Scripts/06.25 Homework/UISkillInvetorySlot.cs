using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UISkillInvetorySlot : MonoBehaviour,
    IDragHandler, IBeginDragHandler, IEndDragHandler,
    IPointerEnterHandler, IPointerExitHandler
{
    #region private º¯¼ö
    Image skillIcon;
    Skill0625 skill;
    #endregion

    public virtual Skill0625 Skill
    {
        get
        {
            return skill;
        }

        set
        {
            skill = value;

            if (skill is null)
            {
                skillIcon.enabled = false;
            }

            else
            {
                skillIcon.sprite = skill.skillIcon;
                skillIcon.enabled = true;
            }
        }
    }

    void Awake()
    {
        skill = null;
        skillIcon = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData data)
    {
        if (skill is null)
        {
            return;
        }

        skillIcon.rectTransform.SetParent(CSkillManager0625.Instance.skillPage);

        //CSkillManager0625.Instance.selectedSlot = this;
    }

    public void OnDrag(PointerEventData data)
    {
        if (skill is null)
        {
            return;
        }

        skillIcon.rectTransform.position = data.position;
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (skill is null)
        {
            return;
        }

        if (CSkillManager0625.Instance.focusedSlot is not null && CSkillManager0625.Instance.focusedSlot != this)
        {
            UISkillInvetorySlot targetSlot = CSkillManager0625.Instance.focusedSlot;
            Skill0625 tempSkill = targetSlot.Skill;

            targetSlot.Skill = skill;
            this.Skill = tempSkill;
        }

        skillIcon.rectTransform.SetParent(transform);
        skillIcon.rectTransform.anchoredPosition = Vector2.zero;
    }

    public void OnPointerEnter(PointerEventData data)
    {
        CSkillManager0625.Instance.focusedSlot = this;
    }

    public void OnPointerExit(PointerEventData data)
    {
        CSkillManager0625.Instance.focusedSlot = null;
    }
}
