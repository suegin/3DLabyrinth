using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    
    public void OnClickLabyrinthTest()
    {
        SceneManager.LoadScene("LabyrinthTest"); // �Q�[���V�[���Ɉړ�
    }
    public void OnClickTitleScene()
    {
        SceneManager.LoadScene("TitleScene"); // �^�C�g���Ɉړ�
    }
}
