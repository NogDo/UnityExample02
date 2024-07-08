using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Player Input Test ������Ʈ�� �ݵ�� CharacterController ������Ʈ�� �־������ ���� �۵��ϵ��� ������ �Ǿ��ֱ� ������
// ������Ʈ�� CharacterController ������Ʈ ������ ������
[RequireComponent(typeof(CharacterController))]
public class CPlayerInputTest : MonoBehaviour
{
    #region public ����
    public float fMoveSpeed;
    public bool useInputSystem;
    #endregion

    #region private ����
    CharacterController cc;

    Vector3 moveDir;
    #endregion

    void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (useInputSystem)
        {
            cc.Move(moveDir * Time.deltaTime * fMoveSpeed);
        }

        else
        {
            Vector2 inputValue = Vector3.zero;

            // GetAxi�� GetAxisRaw�� ���̴� InputManager ������ Gravity�� Sensitivity���� ����
            inputValue.x = Input.GetAxis("Horizontal"); // x�� �� >> a : negative, d : positive
            inputValue.y = Input.GetAxis("Vertical"); // y�� �� >> s : negative, w : positive

            Move(inputValue);
        }
    }

    void Move(Vector2 inputValue)
    {
        moveDir = new Vector3(inputValue.x, 0.0f, inputValue.y);

        cc.Move(moveDir * Time.deltaTime * fMoveSpeed);
    }

    /// <summary>
    /// Player Input ������Ʈ�� ��� �Է¿� �°� SendMessage()�� ���� ȣ��.
    /// </summary>
    /// <param name="inputValue">�Է��� ��</param>
    void OnMove(InputValue inputValue)
    {
        Vector2 inputVector = inputValue.Get<Vector2>();
        moveDir = new Vector3(inputVector.x, 0.0f, inputVector.y);
    }

    void OnAttack(InputValue inputValue)
    {
        print("����");
    }
}