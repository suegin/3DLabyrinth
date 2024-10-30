using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleFade : MonoBehaviour
{
    // ゲーム開始時にフェードインさせるだけ

    private IEnumerator Start()
    {
        // 1フレームだけ待ってやる
        yield return null;
        StartCoroutine(YukiFadeManager.FadeIn(1.0f));
    }
}
