using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRandomQueue : MonoBehaviour
{
    #region private ����
    Queue<Vector3> randomPositionQueue;
    Queue<Color> colorQueue;

    [SerializeField]
    GameObject oSphere;
    #endregion

    #region public ����
    public float fWaitTime;
    #endregion

    void Start()
    {
        randomPositionQueue = new Queue<Vector3>();
        colorQueue = new Queue<Color>();

        StartCoroutine(ActiveRandomQueue());
    }

    /// <summary>
    /// ���� ť �ڷ�ƾ ����, ť�� �����Ͱ� �ִٸ� 1�ʿ� �ѹ��� �����͸� �����ش�.
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
    /// Queue�� �����ǰ��� �÷����� �־��ش�.
    /// </summary>
    /// <param name="buttonIndex">���� ��ư �ε���</param>
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
                print("Color�� �������� �ʾҽ��ϴ�.");
                break;
        }
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
}