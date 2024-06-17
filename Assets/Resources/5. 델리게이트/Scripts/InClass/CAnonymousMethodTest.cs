using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

#region ���� �޼���
/*
 
�� ���� �޼���

- Ŭ���� ���� �ƴ� �޼��� ������ ���ǵǴ� �޼���

- �޼��忡 �̸��� ������, Delegate�� �Ҵ��ϱ� ���ؼ��� �ش� Delegate�� �Ű������� ��ȯ���� Ÿ���� ��ġ�ؾ� ��.


�� ����

- 1ȸ������ ���Ǵ� �Լ��� ���Ǹ� ���� �Լ� �ۿ��� ������ �ʿ䰡 ���� �������� �����ϴ� ������ �ִ�.

- ���������� ���Ǵ� ��������Ʈ ������ �Ҵ��ϴ� ������ ���� ��� �ش� ��Ŀ���� ����Ǹ� �޸� �Ҵ��� �����ϹǷ�
���ʿ��� �Լ��� �޸𸮸� �����ϴ°��� ������ �� �ִ�.


�� ����

- ��������Ʈ ü�̴��� ����� ��, �ش� �޼��常 ü�ο��� �����ϴ� ���� �Ұ����ϴ�.

- ����, �� �޼��忡�� ���� ����޼��带 ������ ��� ������ �������� ������ �� �ִ�.
 
*/
#endregion


#region ���ٽ�
/*
 
�� ���ٽ�

- ���� �޼����� ���� ǥ���̴�.
 
*/
#endregion

public class CAnonymousMethodTest : MonoBehaviour
{
    Action someAction;
    Action someAction2;
    Action<int, float> autoCastPlus;
    Func<int, string> someFunc;
    Func<int, int, string> someFunc2;

    void Awake()
    {
        someAction2 = someAction = delegate ()
        {
            print("anonymous method called.");
        };

        // ���� �޼��带 ������ �� ��� action�� �ϳ� �� �Ἥ ������ �� ����... (��ȿ����)
        someAction2 -= someAction;


        autoCastPlus = delegate (int a, float b)
        {
            int result = a + (int)b;
            print(result);
        };

        // ���� �޼��� �Ҵ翡�� �Ű����� ������ ���ʿ��� ��� ������ �����ϴ�.
        autoCastPlus += delegate
        {
            print("Calc Finished!");
        };


        someFunc = delegate (int a)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("�Էµ� �Ķ���ʹ� : ").Append(a).Append("�Դϴ�.");

            return sb.ToString();
        };


        // ���ٽ� ǥ�� ���
        someAction += (/*�Ķ����*/) => { /*�Լ� ����*/ };
        someFunc += (int a) => { return a + " is intager."; };

        // ���ٽ��� �Ķ������ �ڷ����� return�� ������ �� �ִ�.
        someFunc += (a) => a + " is intager.";
        // �Ķ���Ͱ� 1���� ��� �Ұ�ȣ�� ������ �����ϴ�.
        someFunc += a => a + " is intager.";
        // �Ķ���Ͱ� 2�� �̻��� ��쿡�� �Ұ�ȣ ������ �Ұ���
        someFunc2 = (a, b) => $"{a} + {b} = {a + b}";
    }

    void Start()
    {
        someAction?.Invoke();
        someAction?.Invoke();
        someAction2?.Invoke();
        autoCastPlus?.Invoke(1, 1.1f);
        print(someFunc?.Invoke(923));
        print(someFunc2?.Invoke(1, 2));
    }
}
