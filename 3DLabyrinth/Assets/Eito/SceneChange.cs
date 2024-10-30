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
        SceneManager.LoadScene("TitleScene_Marged"); // �^�C�g���Ɉړ�
    }

    public void OnclickOpeningScene()
    {
        // �I�[�v�j���O�Ɉړ�
        StartCoroutine(SceneChangeOpening());
    }

    private IEnumerator SceneChangeOpening()
    {
        // �t�F�[�h���ăV�[���J��
        yield return YukiFadeManager.FadeOut(1.0f);
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("Opening");
    }
}
