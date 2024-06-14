using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCollectionTest : MonoBehaviour
{
    // �÷����� �����͸� ���������� ����� �� �ִ� Ŭ������ ����
    // 1. �迭
    // 2. ����Ʈ(��̸���Ʈ)
    // 3. ��ųʸ�(�ؽ����̺�)
    // 4. ���� / ť

    #region �迭
    // �迭�� �⺻������ ���۷��� Ÿ���̱� ������ �ʱ�ȭ �Ҵ��� ���� ������ null �����̴�.
    private int[] nArr = new int[5];
    // ���ͷ� Ÿ���� �ʱⰪ�� �Ҵ����� �ʾƵ� �⺻���� �Ҵ��� �ȴ�.
    private int someInt;

    // public ������ �ʱ� �Ҵ翡 ���Ǹ� �ؾ��Ѵ�. (inspectorâ�� reset���� ������ �ʱⰪ�� �Ҵ���� ����)
    public int[] publicArray = new int[10];
    #endregion

    #region ����Ʈ
    // �迭�� ���������, ���������� ũ�� ������ �����ϰ�, ��� �� ���� ����� �����ϴ� �Լ��� ���Ե� Ŭ����
    private List<int> nList = new List<int>();

    public List<int> publicList;
    public List<GameObject> gameObjects;

    // ����Ʈ�� ���������, �߰��� �ڷ����� ������ ���� �ʰ� �⺻������ Boxing�Ǿ� �Ҵ�ȴ�.
    private ArrayList arrayList = new ArrayList();
    #endregion

    #region ��ųʸ�
    // �迭�� �������⵵�� ���� �ð����⵵�� ���� �ڷ����̶��
    // ��ųʸ�(�ؽ����̺�)�� �������⵵�� ���� �ð����⵵�� ���� �ڷ����̴�.
    private Dictionary<string, GameObject> dictionary = new Dictionary<string, GameObject>();

    // ArrayListó�� �ڽ̵� ���·� �ڷ����� �Ҵ�ȴ�.
    private Hashtable hashtable = new Hashtable();

    // ��ųʸ��� inspector���� Ȯ���� �Ұ����ϴ�.
    public Dictionary<string, GameObject> publicDictionary;

    public GameObject cube;
    public GameObject sphere;
    public GameObject cylinder;
    public GameObject capsule;
    #endregion

    #region ���� / ť
    // ����
    private Stack<int> intStack = new Stack<int>();

    // ť
    private Queue<int> intQueue = new Queue<int>();

    #endregion

    // inspector â�� Reset�� �����ԵǸ� ȣ���ϴ� �޼��� �Լ�, ���� ���� �ʱⰪ �Ҵ� ���Ŀ� ȣ��ȴ�.
    void Reset()
    {
        publicArray = new int[15];
    }

    void Start()
    {
        // �迭 ä���
        Array.Fill<int>(nArr, 1);

        // �迭 ��ȸ
        foreach (int value in publicArray)
        {
            //print(value);
        }


        // ����Ʈ ���� �߰�
        nList.Add(1);
        nList.Add(2);
        nList.Add(3);
        nList.Add(4);
        nList.Add(5);

        // ����Ʈ ��ȸ
        foreach (int value in nList)
        {
            //print(value);
        }

        foreach (GameObject obj in gameObjects)
        {
            //print(obj.name);
        }

        // ArrayList ���� �߰�
        arrayList.Add(1);
        arrayList.Add(1.0f);
        arrayList.Add(new GameObject("���� ���� ��ü"));
        arrayList.Add(new ArrayList());

        // ArrayList ��ȸ
        foreach (object element in arrayList)
        {
            //print(element);
        }

        // ArrayList�� �����͸� �߰��� �� �ڽ��� �Ǳ� ������ �ڷ����� ����ϰ� �ʹٸ� ��ڽ��� ���� ����ؾ��Ѵ�.
        //print((arrayList[2] as GameObject).name);


        // ��ųʸ� ���� �߰�
        dictionary.Add("cube", cube);
        dictionary.Add("sphere", sphere);
        dictionary.Add("cylinder", cylinder);
        dictionary.Add("capsule", capsule);

        // ��ųʸ� ����
        dictionary["capsule"].GetComponent<Renderer>().material.color = Color.red;
        dictionary["sphere"].GetComponent<Renderer>().material.color = Color.blue;
        dictionary["cube"].GetComponent<Renderer>().material.color = Color.green;
        dictionary["cylinder"].GetComponent<Renderer>().material.color = Color.black;

        // �ؽ����̺� ���� �߰�
        hashtable.Add("a", 1);
        hashtable.Add(3f, 1);


        // ���� ���� �߰�
        intStack.Push(5);
        intStack.Push(4);
        intStack.Push(3);
        intStack.Push(2);
        intStack.Push(1);

        // ���� ���� ������ ���
        print(intStack.Pop());  // 1
        print(intStack.Pop());  // 2
        print(intStack.Pop());  // 3

        intStack.Push(6);
        intStack.Push(7);

        print(intStack.Pop());  // 7
        print(intStack.Pop());  // 6
        print(intStack.Pop());  // 4
        print(intStack.Pop());  // 5

        // ť ���� �߰�
        intQueue.Enqueue(1);
        intQueue.Enqueue(2);
        intQueue.Enqueue(3);
        intQueue.Enqueue(7);
        intQueue.Enqueue(6);

        // ť ���� ������ ���
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