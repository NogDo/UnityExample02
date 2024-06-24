using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ECurrencyType
{
    COIN,
    FOOD,
    WOOD,
    METAL,
    CRYSTAL
}

// �Լ� �Ǵ� ������ ȣ�� �� [�Ķ�����̸�] = [��] ���·� �Ķ���� ������ ������� ������ �����ϴ�.
[CreateAssetMenu(fileName = "CurrencyData", menuName = "Scriptable Objects/Currency Data", order = 0)]
public class CurrencyData : ScriptableObject
{
    // ��ȭ �����͸� ����ȭ �� Scriptable Obeject
    #region public ����
    public string currencyName;
    public Sprite iconSprite;
    public ECurrencyType currencyType;
    public int maxCount;
    #endregion
}
