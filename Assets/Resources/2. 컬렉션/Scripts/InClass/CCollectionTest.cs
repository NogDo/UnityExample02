using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCollectionTest : MonoBehaviour
{
    // 컬렉션은 데이터를 묶음단위로 취급할 수 있는 클래스의 집합
    // 1. 배열
    // 2. 리스트(어레이리스트)
    // 3. 딕셔너리(해쉬테이블)
    // 4. 스택 / 큐

    #region 배열
    // 배열은 기본적으로 레퍼런스 타입이기 때문에 초기화 할당을 하지 않으면 null 상태이다.
    private int[] nArr = new int[5];
    // 리터럴 타입은 초기값을 할당하지 않아도 기본값이 할당이 된다.
    private int someInt;

    // public 변수는 초기 할당에 유의를 해야한다. (inspector창을 reset하지 않으면 초기값이 할당되지 않음)
    public int[] publicArray = new int[10];
    #endregion

    #region 리스트
    // 배열과 비슷하지만, 유동적으로 크기 변경이 가능하고, 요소 비교 등의 기능을 지원하는 함수가 포함된 클래스
    private List<int> nList = new List<int>();

    public List<int> publicList;
    public List<GameObject> gameObjects;

    // 리스트와 비슷하지만, 추가할 자료형에 제한을 두지 않고 기본적으로 Boxing되어 할당된다.
    private ArrayList arrayList = new ArrayList();
    #endregion

    #region 딕셔너리
    // 배열은 공간복잡도가 낮고 시간복잡도가 높은 자료형이라면
    // 딕셔너리(해시테이블)은 공간복잡도가 높고 시간복잡도가 낮은 자료형이다.
    private Dictionary<string, GameObject> dictionary = new Dictionary<string, GameObject>();

    // ArrayList처럼 박싱된 형태로 자료형이 할당된다.
    private Hashtable hashtable = new Hashtable();

    // 딕셔너리는 inspector에서 확인이 불가능하다.
    public Dictionary<string, GameObject> publicDictionary;

    public GameObject cube;
    public GameObject sphere;
    public GameObject cylinder;
    public GameObject capsule;
    #endregion

    #region 스택 / 큐
    // 스택
    private Stack<int> intStack = new Stack<int>();

    // 큐
    private Queue<int> intQueue = new Queue<int>();

    #endregion

    // inspector 창의 Reset을 누르게되면 호출하는 메세지 함수, 전역 변수 초기값 할당 이후에 호출된다.
    void Reset()
    {
        publicArray = new int[15];
    }

    void Start()
    {
        // 배열 채우기
        Array.Fill<int>(nArr, 1);

        // 배열 순회
        foreach (int value in publicArray)
        {
            //print(value);
        }


        // 리스트 원소 추가
        nList.Add(1);
        nList.Add(2);
        nList.Add(3);
        nList.Add(4);
        nList.Add(5);

        // 리스트 순회
        foreach (int value in nList)
        {
            //print(value);
        }

        foreach (GameObject obj in gameObjects)
        {
            //print(obj.name);
        }

        // ArrayList 원소 추가
        arrayList.Add(1);
        arrayList.Add(1.0f);
        arrayList.Add(new GameObject("내가 만든 객체"));
        arrayList.Add(new ArrayList());

        // ArrayList 순회
        foreach (object element in arrayList)
        {
            //print(element);
        }

        // ArrayList는 데이터를 추가할 때 박싱이 되기 때문에 자료형을 사용하고 싶다면 언박싱을 통해 사용해야한다.
        //print((arrayList[2] as GameObject).name);


        // 딕셔너리 원소 추가
        dictionary.Add("cube", cube);
        dictionary.Add("sphere", sphere);
        dictionary.Add("cylinder", cylinder);
        dictionary.Add("capsule", capsule);

        // 딕셔너리 참조
        dictionary["capsule"].GetComponent<Renderer>().material.color = Color.red;
        dictionary["sphere"].GetComponent<Renderer>().material.color = Color.blue;
        dictionary["cube"].GetComponent<Renderer>().material.color = Color.green;
        dictionary["cylinder"].GetComponent<Renderer>().material.color = Color.black;

        // 해쉬테이블 원소 추가
        hashtable.Add("a", 1);
        hashtable.Add(3f, 1);


        // 스택 원소 추가
        intStack.Push(5);
        intStack.Push(4);
        intStack.Push(3);
        intStack.Push(2);
        intStack.Push(1);

        // 스택 원소 꺼내서 사용
        print(intStack.Pop());  // 1
        print(intStack.Pop());  // 2
        print(intStack.Pop());  // 3

        intStack.Push(6);
        intStack.Push(7);

        print(intStack.Pop());  // 7
        print(intStack.Pop());  // 6
        print(intStack.Pop());  // 4
        print(intStack.Pop());  // 5

        // 큐 원소 추가
        intQueue.Enqueue(1);
        intQueue.Enqueue(2);
        intQueue.Enqueue(3);
        intQueue.Enqueue(7);
        intQueue.Enqueue(6);

        // 큐 원소 꺼내서 사용
        print(intQueue.Dequeue());
        print(intQueue.Dequeue());
        print(intQueue.Dequeue());

        intQueue.Enqueue(4);
        intQueue.Enqueue(5);

        print(intQueue.Dequeue());
        print(intQueue.Dequeue());
        print(intQueue.Dequeue());
        print(intQueue.Dequeue());
    }
}