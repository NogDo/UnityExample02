using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CUIPanelController : MonoBehaviour
{
    public Transform PanelParent;

    public void AddPanelButtonClick()
    {
        var child = new GameObject("Image");
        child.transform.SetParent(PanelParent);
        var childImage = child.AddComponent<Image>();

        CDayNightManager.Instance.onDayComesUp +=
            (isDay) =>
            {
                childImage.color = isDay ? Color.black : Color.white;
            };
    }
}

#region 06.17 ����
/*
������ ������ ������ 4���� ���� �Ӽ��� �ο��Ͽ�, �з����� Ȱ��ȭ / ��Ȱ��ȭ �ǵ��� ��ư�� ���弼��.
�� (ȭ�� : ����, �Ҹ�ǰ) (���� : ����, ���) (���� : ��Ÿ, ���) (���� : ��Ÿ, �Ҹ�ǰ)

ex) ���� ��ư : ȭ��� ������ ���� 1 �������� ���� 0.5
ex) �Ҹ�ǰ ��ư : ȭ��� ������ ���� 1 �������� ���� 0.5

��� ������ ������Ʈ�� List<Item>�� ���� �ϳ��� List���� �����ϼ���.
Ư�� ������ �������� ã�� ��, List.Find �Ǵ� FindAll �޼ҵ带 ����ϼ���.
�Ķ���� ����������Ʈ�� ���� �Ǵ� ���� �޼��� �������� �����ϼ���.

����) ������ �߰� ��ư�� ����� �������� �߰��ɶ����� List�� Add �ϰ�, ������ �������� ������ List���� Remove�Ǹ鼭 Destory�ǵ��� �ϼ���.
*/
#endregion