using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRandomQueue : MonoBehaviour
{
    #region private 변수
    Queue<Vector3> randomPositionQueue;
    Queue<Color> colorQueue;

    [SerializeField]
    GameObject oSphere;
    #endregion

    #region public 변수
    public float fWaitTime;
    #endregion

    void Start()
    {
        randomPositionQueue = new Queue<Vector3>();
        colorQueue = new Queue<Color>();

        StartCoroutine(ActiveRandomQueue());
    }

    /// <summary>
    /// 랜덤 큐 코루틴 실행, 큐에 데이터가 있다면 1초에 한번씩 데이터를 보여준다.
    /// </summary>
    /// <returns></returns>
    IEnumerator ActiveRandomQueue()
    {
        while (true)
        {
            if (randomPositionQueue.Count > 0)
            {
                oSphere.transform.position = randomPositionQueue.Dequeue();
                oSphere.GetComponent<Renderer>().material.color = colorQueue.Dequeue();

                oSphere.SetActive(true);
            }

            yield return new WaitForSeconds(fWaitTime);

            oSphere.SetActive(false);
        }
    }

    /// <summary>
    /// Queue에 포지션값과 컬러값을 넣어준다.
    /// </summary>
    /// <param name="buttonIndex">누른 버튼 인덱스</param>
    public void EnqueueObejct(int buttonIndex)
    {
        randomPositionQueue.Enqueue(GetRandomPosition(-10.0f, 10.0f));

        switch (buttonIndex)
        {
            case 0:
                colorQueue.Enqueue(Color.red);
                break;

            case 1:
                colorQueue.Enqueue(Color.green);
                break;

            case 2:
                colorQueue.Enqueue(Color.blue);
                break;

            default:
                print("Color가 설정되지 않았습니다.");
                break;
        }
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
}