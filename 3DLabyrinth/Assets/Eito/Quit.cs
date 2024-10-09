using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Quit : MonoBehaviour
{
    // ゲームを止める処理をボタンに提供するだけ
    public void QuitGame()
    {
        // エディタかexeかで処理を分岐させよう
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
}
