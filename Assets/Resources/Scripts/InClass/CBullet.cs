using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBullet : MonoBehaviour
{
    #region public 변수
    public LayerMask targetLayer;
    public float fDamage;
    #endregion

    void OnTriggerEnter(Collider other)
    {
        // 충돌한 객체가 타겟 Layer가 아닐 경우 무시하기 위함
        if ((targetLayer | 1 << other.gameObject.layer) != targetLayer)
        {
            return;
        }

        // interface를 활용한 방법
        if (other.TryGetComponent<IHitable>(out IHitable hitable))
        {
            hitable.Hit(fDamage);
        }

        // SendMessage로 다형성 구현
        // 이렇게 구현하는 방식도 있지만 오류를 추적할 수 없고 성능이 떨어진다는 단점이 있다.
        //other.SendMessage("Hit", fDamage, SendMessageOptions.DontRequireReceiver);

        Destroy(gameObject);
    }
}
