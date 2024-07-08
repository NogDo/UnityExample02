using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Player Input Test 컴포넌트는 반드시 CharacterController 컴포넌트가 있어야지만 정상 작동하도록 구현이 되어있기 때문에
// 오브젝트에 CharacterController 컴포넌트 부착을 강제함
[RequireComponent(typeof(CharacterController))]
public class CPlayerInputTest : MonoBehaviour
{
    #region public 변수
    public float fMoveSpeed;
    public bool useInputSystem;
    #endregion

    #region private 변수
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

            // GetAxi와 GetAxisRaw의 차이는 InputManager 세팅의 Gravity와 Sensitivity값을 무시
            inputValue.x = Input.GetAxis("Horizontal"); // x축 값 >> a : negative, d : positive
            inputValue.y = Input.GetAxis("Vertical"); // y축 값 >> s : negative, w : positive

            Move(inputValue);
        }
    }

    void Move(Vector2 inputValue)
    {
        moveDir = new Vector3(inputValue.x, 0.0f, inputValue.y);

        cc.Move(moveDir * Time.deltaTime * fMoveSpeed);
    }

    /// <summary>
    /// Player Input 컴포넌트가 기기 입력에 맞게 SendMessage()를 통해 호출.
    /// </summary>
    /// <param name="inputValue">입력한 값</param>
    void OnMove(InputValue inputValue)
    {
        Vector2 inputVector = inputValue.Get<Vector2>();
        moveDir = new Vector3(inputVector.x, 0.0f, inputVector.y);
    }

    void OnAttack(InputValue inputValue)
    {
        print("공격");
    }
}