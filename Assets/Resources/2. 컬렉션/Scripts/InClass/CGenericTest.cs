using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// where은 제약조건을 거는 것!
public class MyGeneric<SomeType> where SomeType : class, ICloneable
{
    private SomeType someVal;

    public MyGeneric(SomeType someVal)
    {
        this.someVal = someVal;
    }

    public SomeType GetSome()
    {
        return someVal;
    }

    public SomeType GetClone()
    {
        return someVal.Clone() as SomeType;
    }
}

public class CGenericTest : MonoBehaviour
{
    public GameObject sphere1;
    public GameObject sphere2;

    public Action<int, int, float> someAction;
    public Func<int, int, float> someFunc;

    public void SomeAction(int a, int b, float c)
    {
        
    }

    public float SomeFunc(int a, int b)
    {
        return default;
    }


    void Start()
    {
        Renderer sphere1Renderer = sphere1.GetComponent<Renderer>();
        Renderer sphere2Renderer = sphere2.GetComponent<Renderer>();
        sphere1Renderer.material.color = Color.red;
        sphere2Renderer.material.color = Color.blue;

        // Sphere 생성
        GameObject newSphere = Instantiate(sphere1);
        newSphere.name = "newSphere";

        // Sphere 위치를 구체1과 구체2 사이에 두고싶음.
        // 색깔도 구체1과 구체2의 중간값으로 설정하고 싶음.
        newSphere.transform.position = GetMiddle<Vector3>(sphere1.transform.position, sphere2.transform.position);
        newSphere.GetComponent<Renderer>().material.color = GetMiddle<Color>(sphere1Renderer.material.color, sphere2Renderer.material.color);
        // 제네릭을 쓰지 않는 경우 반환 자료형이 고정되어 있어 언박싱을 해야하는 불편함이 있다.
        //(newSphere.GetComponent(typeof(Renderer)) as Renderer).material.color = Color.red;

        // 제네릭 클래스
        //MyGeneric<int> myIntGeneric = new MyGeneric<int>(1);
        //print(myIntGeneric.GetSome());

        MyGeneric<string> myStringGeneric = new MyGeneric<string>("MyGeneric Test");
        print(myStringGeneric.GetSome());

        //MyGeneric<GameObject> myObjectGeneric = new MyGeneric<GameObject>(new GameObject());
        //myObjectGeneric.GetSome().name = "MyGameobjectGeneric";


        // Action
        someAction = SomeAction;

        // Func
        someFunc = SomeFunc;
    }

    /// <summary>
    /// 위치의 중간값을 구하는 함수
    /// </summary>
    /// <param name="a">위치1</param>
    /// <param name="b">위치2</param>
    /// <returns></returns>
    private Vector3 GetMiddle(Vector3 a, Vector3 b)
    {
        Vector3 @return = new Vector3((a.x + b.x) / 2, (a.y + b.y) / 2, (a.z + b.z) / 2);

        return @return;
    }

    /// <summary>
    /// 색상의 중간값을 구하는 함수
    /// </summary>
    /// <param name="a">색상1</param>
    /// <param name="b">색상2</param>
    /// <returns></returns>
    private Color GetMiddle(Color a, Color b)
    {
        Color @return = new Color((a.r + b.r) / 2, (a.g + b.g) / 2, (a.b + b.b) / 2);

        return @return;
    }

    /// <summary>
    /// 제네릭으로 구현한 중간값 함수
    /// </summary>
    /// <typeparam name="T">자료형</typeparam>
    /// <param name="a">타겟1</param>
    /// <param name="b">타겟2</param>
    /// <returns></returns>
    private T GetMiddle<T>(T a, T b) where T : struct
    {
        dynamic da = a;
        dynamic db = b;
        dynamic c = (da + db) / 2;

        return (T)c;
    }
}

#region 06.13 과제
/*
1. Start에서 5개의 Vector3를 무작위로 List.Add 하시오.
2. Start에서 5개의 Color를 무작위로 List.Add 하시오.
3. 코루틴에서 1초 간격으로 두 리스트에 있는 Vector3와 Color로 위치와 색이 바뀌도록 Renderer가 있는 오브젝트를 제어하시오
   ㄴ Cube, Sphere, 등등 아무거나 사용

번외1) 빨강, 파랑, 녹색 버튼을 만들고 Queue에 버튼을 누를때마다 랜덤 위치에 누른 색으로 바뀌도록 Enqueue 하세요.
      ㄴ Vector와 Color 큐를 사용해서 1초 간격으로 나오게끔

번외2) 번외 1을 Queue을 대신해 Stack으로 만들어보자.
*/
#endregion