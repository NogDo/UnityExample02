using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDelegateChainingTest : MonoBehaviour
{
    private OtherDelegateMethod otherDelegate;

    void Start()
    {
        otherDelegate = MessageTrim;
        otherDelegate += MessageAllTrim;
        otherDelegate += MessageDuplicate;
        otherDelegate += MessageAllTrim;
        otherDelegate += MessageLower;
        otherDelegate += MessageAllTrim;

        // 가장 최근에 추가한 메서드를 삭제
        // 델리게이트 체인은 일종의 Stack구조, 같은 메소드 중에서만 선입 후출로 제거된다.
        otherDelegate -= MessageAllTrim;

        otherDelegate?.Invoke("  Hello World");


        otherDelegate += MessageDuplicate;
        otherDelegate += MessageDuplicate;
        otherDelegate += MessageDuplicate;

        // 대입을 하게 되면 위에 내용이 사라짐
        otherDelegate = MessageTrim;

        otherDelegate?.Invoke("  Hello World");
    }

    private void MessageTrim(string message)
    {
        // string.Trim() : 문자열에서 앞 뒤 공백을 제거하여 반환
        print(message.Trim());
    }

    private void MessageAllTrim(string message)
    {
        // string.Replace()를 이용하여 문자열 내부의 공백까지 모두 제거
        print(message.Replace(" ", ""));
    }

    private void MessageDuplicate(string message)
    {
        print(message + message);
    }

    private void MessageLower(string message)
    {
        // string.ToLower() : 문자열의 영문자 대문자를 모두 소문자로 바꿔 반환
        print(message.ToLower());
    }
}