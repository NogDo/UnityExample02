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

#region 06.17 과제
/*
제공된 아이템 아이콘 4개에 각각 속성을 부여하여, 분류별로 활성화 / 비활성화 되도록 버튼을 만드세요.
ㄴ (화살 : 무기, 소모품) (도끼 : 무기, 장비) (망토 : 기타, 장비) (동전 : 기타, 소모품)

ex) 무기 버튼 : 화살과 도끼만 투명도 1 나머지는 투명도 0.5
ex) 소모품 버튼 : 화살과 동전만 투명도 1 나머지는 투명도 0.5

모든 아이템 오브젝트는 List<Item>과 같이 하나의 List에서 관리하세요.
특정 종류의 아이템을 찾을 시, List.Find 또는 FindAll 메소드를 사용하세요.
파라미터 프리디케이트는 람다 또는 무명 메서드 형식으로 정의하세요.

번외) 아이템 추가 버튼을 만들어 아이템이 추가될때마다 List에 Add 하고, 아이템 아이콘을 누르면 List에서 Remove되면서 Destory되도록 하세요.
*/
#endregion