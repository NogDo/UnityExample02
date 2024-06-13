using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerController : MonoBehaviour
{

    #region private º¯¼ö
    CharacterController characterController;
    Transform boxPoint;

    float fMoveSpeed;
    float fRotateSpeed;
    #endregion

    public Transform BoxPoint
    {
        get
        {
            return boxPoint;
        }
    }

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        boxPoint = transform.GetChild(2);

        fMoveSpeed = 3.0f;
        fRotateSpeed = 60.0f;
    }

    void Update()
    {
        Move();
        Rotate();
    }

    public void Move()
    {
        float fHorizontal = Input.GetAxis("Horizontal");
        float fVertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * fVertical + transform.right * fHorizontal;
        moveDirection.y = -1.0f;

        characterController.Move(moveDirection * fMoveSpeed * Time.deltaTime);
    }

    public void Rotate()
    {
        float fHorizontal = Input.GetAxis("Mouse X");

        transform.Rotate(Vector3.up * fHorizontal * fRotateSpeed * Time.deltaTime);
    }
}
