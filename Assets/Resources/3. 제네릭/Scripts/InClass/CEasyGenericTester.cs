using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEasyGenericTester : MonoBehaviour
{
    #region public 변수
    public CCubeParent cubeFrom;
    public CCubeParent cubeTo;
    #endregion

    void Awake()
    {
        // cubeFrom의 colors, xPosition, sacales 배열을 각각 복사하고 싶음.
        cubeTo.colors = ArrayCopy<Color>(cubeFrom.colors);
        cubeTo.xPosition = ArrayCopy<int>(cubeFrom.xPosition);
        cubeTo.scales = ArrayCopy<float>(cubeFrom.scales);
    }

    // 이렇게 복사를 하려고 하면, 하나하나 일일이 다 구현해야함...
    private Color[] ArrayCopy(Color[] from)
    {
        Color[] to = new Color[from.Length];

        for (int i = 0; i < to.Length; i++)
        {
            to[i] = from[i];
        }

        return to;
    }

    // 제네릭을 쓰면 메서드 하나로 다 가능
    private T[] ArrayCopy<T>(T[] from)
    {
        T[] to = new T[from.Length];

        for (int i = 0; i < to.Length; i++)
        {
            to[i] = from[i];
        }

        return to;
    }
}

#region 제네릭 활용
/*

1. 제네릭을 사용하여 정의된 클래스를 자료형으로 사용 또는 함수를 호출
ㄴ 컬렉션 (List<int>, Dictionary<string, GameObject>) 등등...
ㄴ GetComponent<Renderer>() 등등...


2. 직접 제네릭을 사용한 클래스 또는 함수를 정의


▶ 제약사항

- 클래스에서 사용하는 제네릭 자료형에 제약사항을 명시할 수 있다.
 
*/

public class GenericExample : MonoBehaviour
{
    public List<int> intList = new List<int>();
    public Dictionary<int, int> intDictionary = new Dictionary<int, int>();

    void Start()
    {
        new GameObject().AddComponent<SpriteRenderer>();

        StructT<Vector3> a;
        ClassT<GameObject> b;
        //NewT<NoneDefaultConstructorClass> c; 에러
        NewT<object> c;
        ParentT<Child> d;
        InterfaceT<string> e;
        MultiT<Vector3, GameObject, object> f;
    }
}

class NoneDefaultConstructorClass
{
    public NoneDefaultConstructorClass(int a) { }
}

class Parent { }
class Child : Parent { }

// 5가지 제약사항 클래스 뿐만 아니라 함수에서도 제약사항을 걸 수 있다.
class StructT<T> where T : struct { } // 1. 구조체만 가능하게

class ClassT<T> where T : class { } // 2. 클래스만 가능하게

class NewT<T> where T : new() { } // 3. 파라미터가 없는 기본 생성자를 정의한 클래스만 가능하게

class ParentT<T> where T : Parent { } // 4. Parent 클래스를 상속한 클래스만 가능하게

class InterfaceT<T> where T : IComparable { } // 5. IComparable 인터페이스를 구현한 클래스만 가능하게

// 여러개의 제약사항을 걸 수 있다.
class MultiT<T1, T2, T3> where T1 : struct where T2 : class where T3 : new() { }
#endregion

#region 06.14 수업 시간 과제
/*
1. SafeArray<T> 클래스를 만드세요
    a. 생성자에서 배열의 크기를 매개변수로 받고, 해당 크기만큼 배열을 생성하세요
        ㄴ new SafeArray<int>(30);

    b. Get, Set 메서드 또는 인덱서를 활용하여 값을 할당하고, 만약 최대 크기를 넘어가는 배열을 참조할 경우
       에러를 발생 시키지 않는 대신 경고 문구를 콘솔에 출력하세요.
*/
#endregion