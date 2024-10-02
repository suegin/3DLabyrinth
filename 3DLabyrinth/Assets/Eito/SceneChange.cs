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
        SceneManager.LoadScene("TitleScene"); // タイトルに移動
    }
}
