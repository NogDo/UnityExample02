using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CUnityEventTest : MonoBehaviour
{
    #region public 변수
    // 유니티 이벤트 (UnityEvent)
    // 유니티 Inspector에서 델리게이트와 같이 특정 함수를 등록하여 호출 할 수 있도록 만들어진 클래스
    public UnityEvent someEvent;
    public UnityEvent<float> onHpChange;
    public UnityEvent<string> onHpChangeString;
    #endregion

    #region private 변수
    private float fMaxHp = 100.0f;
    private float fCurrentHp = 100.0f;
    private float fHpCache = 100.0f;
    #endregion

    void Start()
    {
        someEvent?.Invoke();

        // 런타임에 메서드 추가, 파라미터 자료형이 맞아야 등록할 수 있다.
        onHpChange.AddListener(PrintCurrentHP);
    }

    void Update()
    {
        if (fHpCache != fCurrentHp)
        {
            onHpChange?.Invoke(fCurrentHp / fMaxHp);
            onHpChangeString?.Invoke((fCurrentHp / fMaxHp).ToString("p1"));
            fHpCache = fCurrentHp;
        }
    }

    public void SomeMethod()
    {
        print("Some Event Called.");
    }

    public void OnValueChanged(float value)
    {
        print(value);
    }

    public void OnPositionChange(Vector2 value)
    {
        transform.position = value;
    }

    public void OnDamageButtonClick()
    {
        fCurrentHp -= 10;
    }

    public void PrintCurrentHP(float value)
    {
        print($"current HP Amount is : {value}");
    }
}

#region 06.18 과제
/*
추가적으로 제공된 아이콘과 밧줄 텍스쳐를 이용하여, Scroll View안에 아이템 사전을 배치하도록 만드세요.
또한 밧줄 텍스쳐가 Scroll View의 스크롤 위치에 따라 움직이도록 제어하는 함수를 만들고
OnValueChanged 이벤트로 호출하여 스크롤 위치와 밧줄 위치가 연동되도록 하세요.

번외) Json 파일을 입출력 했던 것과 같이 Excel 파일(.xlsx확장자)을 쓰고 읽는 모듈을 작성해보세요.
*/
#endregion