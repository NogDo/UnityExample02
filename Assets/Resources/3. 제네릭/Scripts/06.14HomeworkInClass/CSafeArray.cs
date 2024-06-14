using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SafeArray<T>
{
    [SerializeField]
    private T[] mArr_SafeArray;

    public SafeArray(int size)
    {
        mArr_SafeArray = new T[size];
    }

    // 인덱서
    public T this[int i]
    {
        get
        {
            if (i >= mArr_SafeArray.Length)
            {
                Debug.LogWarning($"배열의 크기를 벗어난 Index를 지정했습니다. 배열의 크기 : {mArr_SafeArray.Length}");
                return default;
            }

            else
            {
                return mArr_SafeArray[i];
            }
        }

        set
        {
            if (i >= mArr_SafeArray.Length)
            {
                Debug.LogWarning($"배열의 크기를 벗어난 Index를 지정했습니다. 배열의 크기 : {mArr_SafeArray.Length}");
            }

            else
            {
                mArr_SafeArray[i] = value;
            }
        }
    }

    // 배열 크기
    public int Count
    {
        get
        {
            return mArr_SafeArray.Length;
        }
    }
}

public class CSafeArray : MonoBehaviour
{
    #region public 변수
    public SafeArray<int> intSafeArray;
    public SafeArray<Vector3> v3SafeArray;
    #endregion

    void Start()
    {
        intSafeArray = new SafeArray<int>(5);
        v3SafeArray = new SafeArray<Vector3>(3);

        // int
        intSafeArray[0] = 1;
        intSafeArray[1] = 2;
        intSafeArray[2] = 3;
        intSafeArray[3] = 4;
        intSafeArray[4] = 5;

        for (int i = 0; i < intSafeArray.Count; ++i)
        {
            print($"intSafeArray[{i}] : {intSafeArray[i]}");
        }

        intSafeArray[5] = 6;

        // Vector3
        v3SafeArray[0] = new Vector3(0, 0, 0);
        v3SafeArray[1] = new Vector3(1, 1, 1);
        v3SafeArray[2] = new Vector3(2, 2, 2);

        for (int i = 0; i < v3SafeArray.Count; ++i)
        {
            print($"v3SafeArray[{i}] : {v3SafeArray[i]}");
        }

        v3SafeArray[3] = new Vector3(3, 3, 3);
    }
}
