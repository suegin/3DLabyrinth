using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleFade : MonoBehaviour
{
    // �Q�[���J�n���Ƀt�F�[�h�C�������邾��

    private IEnumerator Start()
    {
        // 1�t���[�������҂��Ă��
        yield return null;
        StartCoroutine(YukiFadeManager.FadeIn(1.0f));
    }
}
