using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRandomList : MonoBehaviour
{
    #region private 변수
    [SerializeField]
    List<GameObject> oRandomList;

    List<Vector3> randomPositionList;
    List<Color> randomColorList;
    #endregion

    #region public 변수
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
    /// 랜덤 위치값을 반환한다.
    /// </summary>
    /// <param name="min">랜덤 최소값</param>
    /// <param name="max">랜덤 최대값</param>
    /// <returns></returns>
    Vector3 GetRandomPosition(float min, float max)
    {
        float fRandomX = Random.Range(min, max);
        float fRandomY = Random.Range(min, max);
        float fRandomZ = Random.Range(min, max);

        return new Vector3(fRandomX, fRandomY, fRandomZ);
    }

    /// <summary>
    /// 랜덤 색상을 반환한다.
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
    /// 1초에 한번씩 게임 오브젝트에 랜덤 리스트에 들어있는 값을 할당하고 보여준다.
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
