using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCoroutineMove : MonoBehaviour
{
    Coroutine mainCoroutine;
    Coroutine moveCoroutine;
    Coroutine rotateCoroutine;

    void Start()
    {
        mainCoroutine = StartCoroutine(MainCoroutine());
    }

    private IEnumerator RotateCoroutine()
    {
        float endTime = Time.time + 5;

        while (Time.time < endTime)
        {
            transform.Rotate(new Vector3(60 * Time.deltaTime, 0, 0));

            yield return null;
        }
    }

    private IEnumerator MoveCoroutine()
    {
        float endTime = Time.time + 5;

        while (Time.time < endTime)
        {
            transform.Translate(new Vector3(0, 1 * Time.deltaTime, 0));

            yield return null;
        }
    }

    private IEnumerator MainCoroutine()
    {
        while (true)
        {
            moveCoroutine = StartCoroutine(MoveCoroutine());
            yield return moveCoroutine;

            rotateCoroutine = StartCoroutine(RotateCoroutine());
            yield return rotateCoroutine;
        }
    }

    public void CoroutineStopButton()
    {
        if (mainCoroutine is not null)
        {
            StopCoroutine(mainCoroutine);
        }

        if (moveCoroutine is not null)
        {
            StopCoroutine(moveCoroutine);
        }

        if (rotateCoroutine is not null)
        {
            StopCoroutine(rotateCoroutine);
        }
    }
}