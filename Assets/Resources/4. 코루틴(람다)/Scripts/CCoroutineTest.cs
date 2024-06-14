using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCoroutineTest : MonoBehaviour
{
    #region public 변수
    public bool continueKey;
    #endregion

    void Start()
    {
        IEnumerator someEnum = SomeEnumerator();

        while (someEnum.MoveNext())
        {
            print(someEnum.Current);
        }

        // 제네릭을 사용하면 return하는 객체가 박싱 언박싱 되지 않는다. (자료형을 특정하기 때문)
        IEnumerator<int> someIntEnum = SomeIntEnumerator();
        int a = 1000;

        while (someIntEnum.MoveNext())
        {
            a -= someIntEnum.Current;
            print(a);
        }

        // foreach 안에는 IEnumerable이 들어간다.
        foreach (Transform child in transform)
        {
            print(child.name);
        }


        IEnumerator thisisCoroutine = ThisisCoroutine();
        thisisCoroutine.MoveNext();
        print("코루틴 한싸이클 넘겼다");

        //StartCoroutine(thisisCoroutine);


        //StartCoroutine(SecondsCoroutine(10, 0.5f));
        //StartCoroutine(RealTimeSecondsCoroutine(10, 0.5f));


        StartCoroutine(UntilCoroutine());
    }

    private IEnumerator SomeEnumerator()
    {
        yield return "하이";

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
        print("코루틴 시작했다.");

        yield return new WaitForSeconds(1.0f);

        print("1초 지났다.");

        yield return new WaitForSeconds(3.0f);

        print("3초 지났다.");

        yield return new WaitForSeconds(4.0f);

        print("4초 지났다.");
    }

    private IEnumerator SecondsCoroutine(int count, float interval)
    {
        float timeTemp = 0.0f;

        for (int i = 0; i < count; i++)
        {
            print($"게임에서 {i} 번 호출 {timeTemp} 초 지남");
            timeTemp += interval;

            yield return new WaitForSeconds(interval);
        }
    }

    private IEnumerator RealTimeSecondsCoroutine(int count, float interval)
    {
        float timeTemp = 0.0f;

        for (int i = 0; i < count; i++)
        {
            print($"실제로 {i} 번 호출 {timeTemp} 초 지남");
            timeTemp += interval;

            yield return new WaitForSecondsRealtime(interval);
        }
    }

    private IEnumerator UntilCoroutine()
    {
        // Until은 함수가 true가 된 순간 다음으로 넘어감
        yield return new WaitUntil(() => { return continueKey; });

        print("컨티뉴 키가 True가 됨");

        // While은 함수가 false가 된 순간 다음으로 넘어감
        yield return new WaitWhile(() => { return continueKey; });

        print("컨티뉴 키가 False가 됨");
    }
}
