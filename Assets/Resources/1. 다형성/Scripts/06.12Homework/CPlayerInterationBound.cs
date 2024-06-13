using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerInterationBound : MonoBehaviour
{
    #region private º¯¼ö
    IInteractable currentInterator;

    bool isCanInteration = false;
    #endregion

    void Update()
    {
        if (isCanInteration)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                currentInterator.Interact();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out IInteractable interactor))
        {
            isCanInteration = true;

            currentInterator = interactor;
            currentInterator.SetActiveCanvas(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out IInteractable interactor))
        {
            isCanInteration = false;

            currentInterator.SetActiveCanvas(false);
        }
    }
}
