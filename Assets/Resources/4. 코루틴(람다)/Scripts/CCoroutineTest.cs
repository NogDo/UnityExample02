using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCoroutineTest : MonoBehaviour
{
    #region public ����
    public bool continueKey;
    #endregion

    void Start()
    {
        IEnumerator someEnum = SomeEnumerator();

        while (someEnum.MoveNext())
        {
            print(someEnum.Current);
        }

        // ���׸��� ����ϸ� return�ϴ� ��ü�� �ڽ� ��ڽ� ���� �ʴ´�. (�ڷ����� Ư���ϱ� ����)
        IEnumerator<int> someIntEnum = SomeIntEnumerator();
        int a = 1000;

        while (someIntEnum.MoveNext())
        {
            a -= someIntEnum.Current;
            print(a);
        }

        // foreach �ȿ��� IEnumerable�� ����.
        foreach (Transform child in transform)
        {
            print(child.name);
        }


        IEnumerator thisisCoroutine = ThisisCoroutine();
        thisisCoroutine.MoveNext();
        print("�ڷ�ƾ �ѽ���Ŭ �Ѱ��");

        //StartCoroutine(thisisCoroutine);


        //StartCoroutine(SecondsCoroutine(10, 0.5f));
        //StartCoroutine(RealTimeSecondsCoroutine(10, 0.5f));


        StartCoroutine(UntilCoroutine());
    }

    private IEnumerator SomeEnumerator()
    {
        yield return "����";

        yield return 1;

        yield return false;

        yield return new object();
    }

    private IEnumerator<int> SomeIntEnumerator()
    {
        yield return 6;
        yield return 2;
        yield return 923;
        yield return -323;
    }

    private IEnumerator ThisisCoroutine()
    {
        print("�ڷ�ƾ �����ߴ�.");

        yield return new WaitForSeconds(1.0f);

        print("1�� ������.");

        yield return new WaitForSeconds(3.0f);

        print("3�� ������.");

        yield return new WaitForSeconds(4.0f);

        print("4�� ������.");
    }

    private IEnumerator SecondsCoroutine(int count, float interval)
    {
        float timeTemp = 0.0f;

        for (int i = 0; i < count; i++)
        {
            print($"���ӿ��� {i} �� ȣ�� {timeTemp} �� ����");
            timeTemp += interval;

            yield return new WaitForSeconds(interval);
        }
    }

    private IEnumerator RealTimeSecondsCoroutine(int count, float interval)
    {
        float timeTemp = 0.0f;

        for (int i = 0; i < count; i++)
        {
            print($"������ {i} �� ȣ�� {timeTemp} �� ����");
            timeTemp += interval;

            yield return new WaitForSecondsRealtime(interval);
        }
    }

    private IEnumerator UntilCoroutine()
    {
        // Until�� �Լ��� true�� �� ���� �������� �Ѿ
        yield return new WaitUntil(() => { return continueKey; });

        print("��Ƽ�� Ű�� True�� ��");

        // While�� �Լ��� false�� �� ���� �������� �Ѿ
        yield return new WaitWhile(() => { return continueKey; });

        print("��Ƽ�� Ű�� False�� ��");
    }
}
