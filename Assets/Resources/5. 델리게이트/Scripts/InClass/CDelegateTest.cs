using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 델리게이트
/*

▶ Delegate (대리자) 

- C++의 함수포인터와 유사한 기능이다.

- 메서드를 변수처럼 가변적으로 활용할 수 있는 기능


▷ Delegate 정의

- 일종의 (레퍼런스)자료형처럼 형식을 지정하도록 선언해야 한다.

- [접근 지정자] delegate [함수의 반환형] [이름]([매개변수]); 의 형식으로 작성

- Delegate의 정의 Scope(위치)는 class, enum과 동일하게 클래스 안과 밖에 정의이 가능하다.
 
*/
#endregion

public delegate float SomeDelegateMethod(float x, float y);
public delegate void OtherDelegateMethod(string message);

public class CDelegateTest : MonoBehaviour
{
    // Delegate 필드 선언
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
        // 매개변수가 암시적 캐스팅이 가능한 경우에도 가능
        otherDelegate = print;

        // Delegate도 인스턴스를 참조하는 형식으로 생성된다.
        otherDelegate = null;
        otherDelegate = new OtherDelegateMethod(PrintMessage);

        // ?연산을 활용해 null을 체크할 수 있다. (null일 경우 참조를 하지 않음)
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
