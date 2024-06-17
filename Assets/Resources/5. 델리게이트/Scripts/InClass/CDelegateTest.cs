using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ��������Ʈ
/*

�� Delegate (�븮��) 

- C++�� �Լ������Ϳ� ������ ����̴�.

- �޼��带 ����ó�� ���������� Ȱ���� �� �ִ� ���


�� Delegate ����

- ������ (���۷���)�ڷ���ó�� ������ �����ϵ��� �����ؾ� �Ѵ�.

- [���� ������] delegate [�Լ��� ��ȯ��] [�̸�]([�Ű�����]); �� �������� �ۼ�

- Delegate�� ���� Scope(��ġ)�� class, enum�� �����ϰ� Ŭ���� �Ȱ� �ۿ� ������ �����ϴ�.
 
*/
#endregion

public delegate float SomeDelegateMethod(float x, float y);
public delegate void OtherDelegateMethod(string message);

public class CDelegateTest : MonoBehaviour
{
    // Delegate �ʵ� ����
    public SomeDelegateMethod someDelegate;
    public OtherDelegateMethod otherDelegate;

    public float x;
    public float y;

    void Start()
    {
        //someDelegate = Plus;
        //someDelegate = Minus;
        //someDelegate = Multiple;
        //someDelegate = Divide;

        otherDelegate = PrintMessage;
        // �Ű������� �Ͻ��� ĳ������ ������ ��쿡�� ����
        otherDelegate = print;

        // Delegate�� �ν��Ͻ��� �����ϴ� �������� �����ȴ�.
        otherDelegate = null;
        otherDelegate = new OtherDelegateMethod(PrintMessage);

        // ?������ Ȱ���� null�� üũ�� �� �ִ�. (null�� ��� ������ ���� ����)
        otherDelegate?.Invoke("");
    }

    public void CalcChagne(int i)
    {
        switch (i)
        {
            case 0:
                someDelegate = Plus;
                break;

            case 1:
                someDelegate = Minus;
                break;

            case 2:
                someDelegate = Multiple;
                break;

            case 3:
                someDelegate = Divide;
                break;
        }
    }

    public void ButtonClick()
    {
        print(someDelegate?.Invoke(x, y));
    }

    public float Plus(float x, float y)
    {
        return x + y;
    }

    public float Minus(float x, float y)
    {
        return x - y;
    }

    public float Multiple(float x, float y)
    {
        return x * y;
    }

    public float Divide(float x, float y)
    {
        return x / y;
    }

    public void PrintMessage(string message)
    {
        print(message);
    }
}
