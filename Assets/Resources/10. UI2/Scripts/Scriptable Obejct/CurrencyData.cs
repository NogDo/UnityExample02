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

// 함수 또는 생성자 호출 시 [파라미터이름] = [값] 형태로 파라미터 순서에 상관없이 전달이 가능하다.
[CreateAssetMenu(fileName = "CurrencyData", menuName = "Scriptable Objects/Currency Data", order = 0)]
public class CurrencyData : ScriptableObject
{
    // 재화 데이터를 구조화 한 Scriptable Obeject
    #region public 변수
    public string currencyName;
    public Sprite iconSprite;
    public ECurrencyType currencyType;
    public int maxCount;
    #endregion
}
