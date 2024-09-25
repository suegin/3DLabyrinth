using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ゲーム中に1個だけ存在する
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // フレームレートを60に固定
        Application.targetFrameRate = 60;
        // これをDontDestroyにする
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
