using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBullet : MonoBehaviour
{
    #region public ����
    public LayerMask targetLayer;
    public float fDamage;
    #endregion

    void OnTriggerEnter(Collider other)
    {
        // �浹�� ��ü�� Ÿ�� Layer�� �ƴ� ��� �����ϱ� ����
        if ((targetLayer | 1 << other.gameObject.layer) != targetLayer)
        {
            return;
        }

        // interface�� Ȱ���� ���
        if (other.TryGetComponent<IHitable>(out IHitable hitable))
        {
            hitable.Hit(fDamage);
        }

        // SendMessage�� ������ ����
        // �̷��� �����ϴ� ��ĵ� ������ ������ ������ �� ���� ������ �������ٴ� ������ �ִ�.
        //other.SendMessage("Hit", fDamage, SendMessageOptions.DontRequireReceiver);

        Destroy(gameObject);
    }
}
