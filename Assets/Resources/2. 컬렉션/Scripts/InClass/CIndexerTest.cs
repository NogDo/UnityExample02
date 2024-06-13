using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 인덱서, 프로퍼티의 배열 버전이다.
public class MyIndexer
{
    private int[] a = new int[10];
    private string temp = string.Empty;

    public int this[int i]
    {
        get
        {
            return a[i];
        }

        set
        {
            a[i] = value;
        }
    }

    public string this[string a]
    {
        get
        {
            if (a == "a")
            {
                return "apple";
            }

            if (a == "b")
            {
                return "boat";
            }

            return temp;
        }

        set
        {
            if (a != "a" || a != "b")
            {
                temp = value;
            }
        }
    }

    public MyIndexer()
    {
        for (int i = 0; i < a.Length; i++)
        {
            a[i] = i;
        }
    }
}

public class CIndexerTest : MonoBehaviour
{

    void Start()
    {
        MyIndexer myIndexer = new MyIndexer();

        print(myIndexer[0]);

        print(myIndexer["a"]);

        myIndexer["abc"] = "abc";
        print(myIndexer["c"]);
    }
}
