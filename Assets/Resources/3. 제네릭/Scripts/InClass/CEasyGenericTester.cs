using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEasyGenericTester : MonoBehaviour
{
    #region public ����
    public CCubeParent cubeFrom;
    public CCubeParent cubeTo;
    #endregion

    void Awake()
    {
        // cubeFrom�� colors, xPosition, sacales �迭�� ���� �����ϰ� ����.
        cubeTo.colors = ArrayCopy<Color>(cubeFrom.colors);
        cubeTo.xPosition = ArrayCopy<int>(cubeFrom.xPosition);
        cubeTo.scales = ArrayCopy<float>(cubeFrom.scales);
    }

    // �̷��� ���縦 �Ϸ��� �ϸ�, �ϳ��ϳ� ������ �� �����ؾ���...
    private Color[] ArrayCopy(Color[] from)
    {
        Color[] to = new Color[from.Length];

        for (int i = 0; i < to.Length; i++)
        {
            to[i] = from[i];
        }

        return to;
    }

    // ���׸��� ���� �޼��� �ϳ��� �� ����
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

#region ���׸� Ȱ��
/*

1. ���׸��� ����Ͽ� ���ǵ� Ŭ������ �ڷ������� ��� �Ǵ� �Լ��� ȣ��
�� �÷��� (List<int>, Dictionary<string, GameObject>) ���...
�� GetComponent<Renderer>() ���...


2. ���� ���׸��� ����� Ŭ���� �Ǵ� �Լ��� ����


�� �������

- Ŭ�������� ����ϴ� ���׸� �ڷ����� ��������� ����� �� �ִ�.
 
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
        //NewT<NoneDefaultConstructorClass> c; ����
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

// 5���� ������� Ŭ���� �Ӹ� �ƴ϶� �Լ������� ��������� �� �� �ִ�.
class StructT<T> where T : struct { } // 1. ����ü�� �����ϰ�

class ClassT<T> where T : class { } // 2. Ŭ������ �����ϰ�

class NewT<T> where T : new() { } // 3. �Ķ���Ͱ� ���� �⺻ �����ڸ� ������ Ŭ������ �����ϰ�

class ParentT<T> where T : Parent { } // 4. Parent Ŭ������ ����� Ŭ������ �����ϰ�

class InterfaceT<T> where T : IComparable { } // 5. IComparable �������̽��� ������ Ŭ������ �����ϰ�

// �������� ��������� �� �� �ִ�.
class MultiT<T1, T2, T3> where T1 : struct where T2 : class where T3 : new() { }
#endregion

#region 06.14 ���� �ð� ����
/*
1. SafeArray<T> Ŭ������ ���弼��
    a. �����ڿ��� �迭�� ũ�⸦ �Ű������� �ް�, �ش� ũ�⸸ŭ �迭�� �����ϼ���
        �� new SafeArray<int>(30);

    b. Get, Set �޼��� �Ǵ� �ε����� Ȱ���Ͽ� ���� �Ҵ��ϰ�, ���� �ִ� ũ�⸦ �Ѿ�� �迭�� ������ ���
       ������ �߻� ��Ű�� �ʴ� ��� ��� ������ �ֿܼ� ����ϼ���.
*/
#endregion