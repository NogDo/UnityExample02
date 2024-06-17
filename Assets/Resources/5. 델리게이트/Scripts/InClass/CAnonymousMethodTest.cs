using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

#region 무명 메서드
/*
 
▶ 무명 메서드

- 클래스 내가 아닌 메서드 내에서 정의되는 메서드

- 메서드에 이름이 없으며, Delegate에 할당하기 위해서는 해당 Delegate와 매개변수와 반환형의 타입이 일치해야 함.


▷ 장점

- 1회성으로 사용되는 함수의 정의를 따로 함수 밖에서 구현할 필요가 없어 가독성이 증가하는 측면이 있다.

- 지역적으로 사용되는 델리게이트 변수에 할당하는 식으로 사용될 경우 해당 포커스가 종료되면 메모리 할당을 해제하므로
불필요한 함수가 메모리를 점유하는것을 방지할 수 있다.


▷ 단점

- 델리게이트 체이닝을 사용할 때, 해당 메서드만 체인에서 제거하는 것이 불가능하다.

- 또한, 한 메서드에서 많은 무명메서드를 정의할 경우 오히려 가독성이 떨어질 수 있다.
 
*/
#endregion


#region 람다식
/*
 
▶ 람다식

- 무명 메서드의 축약식 표현이다.
 
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

        // 무명 메서드를 지워야 할 경우 action을 하나 더 써서 제거할 수 있음... (비효율적)
        someAction2 -= someAction;


        autoCastPlus = delegate (int a, float b)
        {
            int result = a + (int)b;
            print(result);
        };

        // 무명 메서드 할당에서 매개변수 참조가 불필요할 경우 생략이 가능하다.
        autoCastPlus += delegate
        {
            print("Calc Finished!");
        };


        someFunc = delegate (int a)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("입력된 파라미터는 : ").Append(a).Append("입니다.");

            return sb.ToString();
        };


        // 람다식 표현 방법
        someAction += (/*파라미터*/) => { /*함수 본문*/ };
        someFunc += (int a) => { return a + " is intager."; };

        // 람다식은 파라미터의 자료형과 return을 생략할 수 있다.
        someFunc += (a) => a + " is intager.";
        // 파라미터가 1개일 경우 소괄호도 생략이 가능하다.
        someFunc += a => a + " is intager.";
        // 파라미터가 2개 이상일 경우에는 소괄호 생략이 불가능
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
