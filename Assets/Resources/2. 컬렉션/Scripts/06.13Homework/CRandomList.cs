using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRandomList : MonoBehaviour
{
    #region private ����
    [SerializeField]
    List<GameObject> oRandomList;

    List<Vector3> randomPositionList;
    List<Color> randomColorList;
    #endregion

    #region public ����
    public float fWaitTime;
    #endregion

    void Start()
    {
        randomPositionList = new List<Vector3>();
        randomColorList = new List<Color>();

        for (int i = 0; i < oRandomList.Count; ++i)
        {
            randomPositionList.Add(GetRandomPosition(-10.0f, 10.0f));
            randomColorList.Add(GetRandomColor());
        }

        StartCoroutine(ActiveRandomList());
    }

    /// <summary>
    /// ���� ��ġ���� ��ȯ�Ѵ�.
    /// </summary>
    /// <param name="min">���� �ּҰ�</param>
    /// <param name="max">���� �ִ밪</param>
    /// <returns></returns>
    Vector3 GetRandomPosition(float min, float max)
    {
        float fRandomX = Random.Range(min, max);
        float fRandomY = Random.Range(min, max);
        float fRandomZ = Random.Range(min, max);

        return new Vector3(fRandomX, fRandomY, fRandomZ);
    }

    /// <summary>
    /// ���� ������ ��ȯ�Ѵ�.
    /// </summary>
    /// <returns></returns>
    Color GetRandomColor()
    {
        float fRed = Random.Range(0.0f, 1.0f);
        float fGreen = Random.Range(0.0f, 1.0f);
        float fBlue = Random.Range(0.0f, 1.0f);

        return new Color(fRed, fGreen, fBlue);
    }

    /// <summary>
    /// 1�ʿ� �ѹ��� ���� ������Ʈ�� ���� ����Ʈ�� ����ִ� ���� �Ҵ��ϰ� �����ش�.
    /// </summary>
    /// <returns></returns>
    IEnumerator ActiveRandomList()
    {
        for (int i = 0; i < oRandomList.Count; ++i)
        {
            oRandomList[i].transform.position = randomPositionList[i];
            oRandomList[i].GetComponent<Renderer>().material.color = randomColorList[i];

            oRandomList[i].SetActive(true);

            yield return new WaitForSeconds(fWaitTime);

            oRandomList[i].SetActive(false);
        }
    }
}
