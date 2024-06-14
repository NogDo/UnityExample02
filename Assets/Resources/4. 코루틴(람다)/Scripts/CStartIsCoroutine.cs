using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CStartIsCoroutine : MonoBehaviour
{
    // Start �޽��� �Լ��� ��ȯ���� void�� �ƴ� Ienumerator�� �� �� �ִ�.
    IEnumerator Start()
    {
        print(@"""Start"" started.");

        yield return new WaitForSeconds(5f);

        print(@"""Start"" end.");
    }
}

#region ������Ʈ ���ǻ���
/*
1. URP / HDRP ������ Built-in�� ���

2. ���� ������ �۰� ��� ��� ��� �ִ��� Ȱ���� �� �ֵ���

3. ����� ���µ��� �̸� Ž���ϼ���. (�̸� �����Ұ�)
*/
#endregion