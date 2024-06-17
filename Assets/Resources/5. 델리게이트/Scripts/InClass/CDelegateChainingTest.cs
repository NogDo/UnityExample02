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

        // ���� �ֱٿ� �߰��� �޼��带 ����
        // ��������Ʈ ü���� ������ Stack����, ���� �޼ҵ� �߿����� ���� ����� ���ŵȴ�.
        otherDelegate -= MessageAllTrim;

        otherDelegate?.Invoke("  Hello World");


        otherDelegate += MessageDuplicate;
        otherDelegate += MessageDuplicate;
        otherDelegate += MessageDuplicate;

        // ������ �ϰ� �Ǹ� ���� ������ �����
        otherDelegate = MessageTrim;

        otherDelegate?.Invoke("  Hello World");
    }

    private void MessageTrim(string message)
    {
        // string.Trim() : ���ڿ����� �� �� ������ �����Ͽ� ��ȯ
        print(message.Trim());
    }

    private void MessageAllTrim(string message)
    {
        // string.Replace()�� �̿��Ͽ� ���ڿ� ������ ������� ��� ����
        print(message.Replace(" ", ""));
    }

    private void MessageDuplicate(string message)
    {
        print(message + message);
    }

    private void MessageLower(string message)
    {
        // string.ToLower() : ���ڿ��� ������ �빮�ڸ� ��� �ҹ��ڷ� �ٲ� ��ȯ
        print(message.ToLower());
    }
}