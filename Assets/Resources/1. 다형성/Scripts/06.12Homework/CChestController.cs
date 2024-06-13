using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CChestController : MonoBehaviour, IInteractable
{

    #region private º¯¼ö
    Animator animator;
    GameObject oCanvas;
    #endregion

    void Start()
    {
        animator = GetComponent<Animator>();
        oCanvas = transform.GetChild(0).gameObject;
    }

    public void Interact()
    {
        if (animator.GetBool("IsOpen"))
        {
            animator.SetBool("IsOpen", false);
        }

        else
        {
            animator.SetBool("IsOpen", true);
        }
    }

    public void SetActiveCanvas(bool active)
    {
        oCanvas.SetActive(active);
    }
}
