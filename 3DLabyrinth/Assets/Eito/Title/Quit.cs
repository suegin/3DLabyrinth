using UnityEngine;

public class Quit : MonoBehaviour
{
    // ゲームを止める処理をボタンに提供するだけ
    public void QuitGame()
    {
        // エディタかexeかで処理を分岐させよう
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
