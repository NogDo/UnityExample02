using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDotnetDelegateTest : MonoBehaviour
{
    // Action ��������Ʈ : �⺻���� ������ ��������Ʈ�� ��ݿ��� �����Ͽ� ����, ��ȯ���� ���� �޼ҵ�
    Action action;
    // Action ��������Ʈ�� ���׸� Ÿ���� �Ķ���� Ÿ���� ����
    Action<int> actionWithIntParam;
    Action<float, float> actionWithTwoFloatParam;

    // Func ��������Ʈ : ��ȯ���� �ִ� ������ ��������Ʈ�� ��ݿ��� �����Ͽ� ����
    Func<object> func;
    // Func ��������Ʈ�� ���׸� Ÿ�� �� �� �ڴ� ��ȯ��, �� ���� �Ķ���� Ÿ���� ����
    Func<string, int> parseFunc;

    // Predicate ��������Ʈ : ��ȯ���� bool�̰�, 1�� �̻��� �Ķ���Ͱ� �ִ� ������ ��������Ʈ
    Predicate<float> predicate;

    void Start()
    {
        action = SomeAction;
        actionWithIntParam = SomeActionWithParam;

        parseFunc = Parse;


        // Predicate ��� ����
        // Predicate�� ���, �Ϻ� �÷��� �Լ��� ���� �Ǵ��� ���� ���Ǹ� Bool�� �����ϴ� �Լ��� ���·� �ޱ� ���� Ȱ���.
        List<int> intList = new List<int>();

        intList.Add(5);
        intList.Add(6);
        intList.Add(8);
        intList.Add(9);
        intList.Add(10);

        // intList���� ¦���� �̾ƿ��� �ʹ�.
        List<int> evenList = intList.FindAll(IsEven);

        foreach (int i in evenList)
        {
            print(i);
        }

        // ¦���� FindAll �� �� ���� �޼��带 ����� ���
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
