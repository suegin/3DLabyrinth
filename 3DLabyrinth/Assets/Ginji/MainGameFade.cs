using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameFade : MonoBehaviour
{
    // Start is called before the first frame update
    private IEnumerator Start()
    {
        yield return null;

        StartCoroutine(YukiFadeManager.FadeIn(1.0f));
    }
}
