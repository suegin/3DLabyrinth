using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    
    public void OnClickLabyrinthTest()
    {
        SceneManager.LoadScene("LabyrinthTest"); // ゲームシーンに移動
    }
    public void OnClickTitleScene()
    {
        SceneManager.LoadScene("TitleScene_Marged"); // タイトルに移動
    }

    public void OnclickOpeningScene()
    {
        // オープニングに移動
        StartCoroutine(SceneChangeOpening());
    }

    private IEnumerator SceneChangeOpening()
    {
        // フェードしてシーン遷移
        yield return YukiFadeManager.FadeOut(1.0f);
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("Opening");
    }
}
