using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CStartIsCoroutine : MonoBehaviour
{
    // Start 메시지 함수는 반환형이 void가 아닌 Ienumerator로 쓸 수 있다.
    IEnumerator Start()
    {
        print(@"""Start"" started.");

        yield return new WaitForSeconds(5f);

        print(@"""Start"" end.");
    }
}

#region 프로젝트 유의사항
/*
1. URP / HDRP 사용금지 Built-in만 사용

2. 게임 볼륨은 작게 대신 배운 기능 최대한 활용할 수 있도록

3. 사용할 에셋들을 미리 탐색하세요. (미리 언팩할것)
*/
#endregion