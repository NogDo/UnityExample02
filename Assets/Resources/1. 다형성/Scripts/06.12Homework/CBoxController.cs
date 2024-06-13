using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBoxController : MonoBehaviour, IInteractable
{
    #region private º¯¼ö
    Rigidbody rbBox;
    GameObject oCanvas;
    #endregion

    void Start()
    {
        rbBox = GetComponent<Rigidbody>();
        oCanvas = transform.GetChild(0).gameObject;
    }

    public void Interact()
    {
        if (rbBox.isKinematic)
        {
            rbBox.isKinematic = false;

            transform.parent = null;
            rbBox.AddForce(transform.forward * 10.0f, ForceMode.Impulse);
        }

        else
        {
            CPlayerController player = FindObjectOfType<CPlayerController>();

            transform.parent = player.BoxPoint;
            transform.localPosition = Vector3.zero;
            transform.rotation = player.transform.rotation;

            rbBox.isKinematic = true;
        }
    }

    public void SetActiveCanvas(bool active)
    {
        oCanvas.SetActive(active);
    }
}
