using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRopeController : MonoBehaviour
{
    #region private º¯¼ö
    RectTransform rectTransform;
    Vector2 v2StartPosition;
    #endregion

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        v2StartPosition = rectTransform.localPosition;
    }

    public void MoveRope(Vector2 position)
    {
        float movePower = (1 - position.y) * 500;
        rectTransform.localPosition = new Vector2(v2StartPosition.x, v2StartPosition.y + movePower);
    }
}
