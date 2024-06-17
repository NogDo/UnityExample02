using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDotnetDelegateTest : MonoBehaviour
{
    // Action 델리게이트 : 기본적인 형택의 델리게이트를 닷넷에서 정의하여 제공, 반환형이 없는 메소드
    Action action;
    // Action 델리게이트에 제네릭 타입은 파라미터 타입을 지정
    Action<int> actionWithIntParam;
    Action<float, float> actionWithTwoFloatParam;

    // Func 델리게이트 : 반환형이 있는 형태의 델리게이트를 닷넷에서 정의하여 제공
    Func<object> func;
    // Func 델리게이트는 제네릭 타입 중 맨 뒤는 반환형, 그 앞은 파라미터 타입을 지정
    Func<string, int> parseFunc;

    // Predicate 델리게이트 : 반환형이 bool이고, 1개 이상의 파라미터가 있는 형태의 델리게이트
    Predicate<float> predicate;

    void Start()
    {
        action = SomeAction;
        actionWithIntParam = SomeActionWithParam;

        parseFunc = Parse;

        // Predicate 사용 이유
        // Predicate의 경우, 일부 컬렉션 함수의 조건 판단을 위한 정의를 Bool을 리턴하는 함수의 형태로 받기 위해 활용됨.
        List<int> intList = new List<int>();

        intList.Add(5);
        intList.Add(6);
        intList.Add(8);
        intList.Add(9);
        intList.Add(10);


        // intList에서 짝수만 뽑아오고 싶다.
        List<int> evenList = intList.FindAll(IsEven);

        foreach (int i in evenList)
        {
            print(i);
        }

        // 짝수를 FindAll 할 때 무명 메서드를 사용할 경우
        List<int> evenListAnonymousMethod = intList.FindAll(
            delegate (int param)
            {
                return param % 2 == 0;
            }
        );
    }

    private void SomeAction()
    {

    }

    private void SomeActionWithParam(int a)
    {

    }

    private int Parse(string param)
    {
        return int.Parse(param);
    }

    private bool IsEven(int param)
    {
        return param % 2 == 0;
    }
}
