using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// where�� ���������� �Ŵ� ��!
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

        // Sphere ����
        GameObject newSphere = Instantiate(sphere1);
        newSphere.name = "newSphere";

        // Sphere ��ġ�� ��ü1�� ��ü2 ���̿� �ΰ����.
        // ���� ��ü1�� ��ü2�� �߰������� �����ϰ� ����.
        newSphere.transform.position = GetMiddle<Vector3>(sphere1.transform.position, sphere2.transform.position);
        newSphere.GetComponent<Renderer>().material.color = GetMiddle<Color>(sphere1Renderer.material.color, sphere2Renderer.material.color);
        // ���׸��� ���� �ʴ� ��� ��ȯ �ڷ����� �����Ǿ� �־� ��ڽ��� �ؾ��ϴ� �������� �ִ�.
        //(newSphere.GetComponent(typeof(Renderer)) as Renderer).material.color = Color.red;

        // ���׸� Ŭ����
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
    /// ��ġ�� �߰����� ���ϴ� �Լ�
    /// </summary>
    /// <param name="a">��ġ1</param>
    /// <param name="b">��ġ2</param>
    /// <returns></returns>
    private Vector3 GetMiddle(Vector3 a, Vector3 b)
    {
        Vector3 @return = new Vector3((a.x + b.x) / 2, (a.y + b.y) / 2, (a.z + b.z) / 2);

        return @return;
    }

    /// <summary>
    /// ������ �߰����� ���ϴ� �Լ�
    /// </summary>
    /// <param name="a">����1</param>
    /// <param name="b">����2</param>
    /// <returns></returns>
    private Color GetMiddle(Color a, Color b)
    {
        Color @return = new Color((a.r + b.r) / 2, (a.g + b.g) / 2, (a.b + b.b) / 2);

        return @return;
    }

    /// <summary>
    /// ���׸����� ������ �߰��� �Լ�
    /// </summary>
    /// <typeparam name="T">�ڷ���</typeparam>
    /// <param name="a">Ÿ��1</param>
    /// <param name="b">Ÿ��2</param>
    /// <returns></returns>
    private T GetMiddle<T>(T a, T b) where T : struct
    {
        dynamic da = a;
        dynamic db = b;
        dynamic c = (da + db) / 2;

        return (T)c;
    }
}

#region 06.13 ����
/*
1. Start���� 5���� Vector3�� �������� List.Add �Ͻÿ�.
2. Start���� 5���� Color�� �������� List.Add �Ͻÿ�.
3. �ڷ�ƾ���� 1�� �������� �� ����Ʈ�� �ִ� Vector3�� Color�� ��ġ�� ���� �ٲ�� Renderer�� �ִ� ������Ʈ�� �����Ͻÿ�
   �� Cube, Sphere, ��� �ƹ��ų� ���

����1) ����, �Ķ�, ��� ��ư�� ����� Queue�� ��ư�� ���������� ���� ��ġ�� ���� ������ �ٲ�� Enqueue �ϼ���.
      �� Vector�� Color ť�� ����ؼ� 1�� �������� �����Բ�

����2) ���� 1�� Queue�� ����� Stack���� ������.
*/
#endregion