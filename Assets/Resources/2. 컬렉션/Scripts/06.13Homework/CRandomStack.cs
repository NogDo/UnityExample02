using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRandomStack : MonoBehaviour
{
    #region private ����
    Stack<Vector3> randomPositionStack;
    Stack<Color> colorStack;

    [SerializeField]
    GameObject oSphere;
    #endregion

    #region public ����
    public float fWaitTime;
    #endregion

    void Start()
    {
        randomPositionStack = new Stack<Vector3>();
        colorStack = new Stack<Color>();

        StartCoroutine(ActiveRandomStack());
    }

    /// <summary>
    /// ���� ť �ڷ�ƾ ����, ť�� �����Ͱ� �ִٸ� 1�ʿ� �ѹ��� �����͸� �����ش�.
    /// </summary>
    /// <returns></returns>
    IEnumerator ActiveRandomStack()
    {
        while (true)
        {
            if (randomPositionStack.Count > 0)
            {
                oSphere.transform.position = randomPositionStack.Pop();
                oSphere.GetComponent<Renderer>().material.color = colorStack.Pop();

                oSphere.SetActive(true);
            }

            yield return new WaitForSeconds(fWaitTime);

            oSphere.SetActive(false);
        }
    }

    /// <summary>
    /// Stack�� �����ǰ��� �÷����� �־��ش�.
    /// </summary>
    /// <param name="buttonIndex">���� ��ư �ε���</param>
    public void PushObejct(int buttonIndex)
    {
        randomPositionStack.Push(GetRandomPosition(-10.0f, 10.0f));

        switch (buttonIndex)
        {
            case 0:
                colorStack.Push(Color.red);
                break;

            case 1:
                colorStack.Push(Color.green);
                break;

            case 2:
                colorStack.Push(Color.blue);
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