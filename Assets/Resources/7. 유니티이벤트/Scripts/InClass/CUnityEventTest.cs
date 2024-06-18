using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CUnityEventTest : MonoBehaviour
{
    #region public ����
    // ����Ƽ �̺�Ʈ (UnityEvent)
    // ����Ƽ Inspector���� ��������Ʈ�� ���� Ư�� �Լ��� ����Ͽ� ȣ�� �� �� �ֵ��� ������� Ŭ����
    public UnityEvent someEvent;
    public UnityEvent<float> onHpChange;
    public UnityEvent<string> onHpChangeString;
    #endregion

    #region private ����
    private float fMaxHp = 100.0f;
    private float fCurrentHp = 100.0f;
    private float fHpCache = 100.0f;
    #endregion

    void Start()
    {
        someEvent?.Invoke();

        // ��Ÿ�ӿ� �޼��� �߰�, �Ķ���� �ڷ����� �¾ƾ� ����� �� �ִ�.
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

#region 06.18 ����
/*
�߰������� ������ �����ܰ� ���� �ؽ��ĸ� �̿��Ͽ�, Scroll View�ȿ� ������ ������ ��ġ�ϵ��� ���弼��.
���� ���� �ؽ��İ� Scroll View�� ��ũ�� ��ġ�� ���� �����̵��� �����ϴ� �Լ��� �����
OnValueChanged �̺�Ʈ�� ȣ���Ͽ� ��ũ�� ��ġ�� ���� ��ġ�� �����ǵ��� �ϼ���.

����) Json ������ ����� �ߴ� �Ͱ� ���� Excel ����(.xlsxȮ����)�� ���� �д� ����� �ۼ��غ�����.
*/
#endregion