using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Quit : MonoBehaviour
{
    // �Q�[�����~�߂鏈�����{�^���ɒ񋟂��邾��
    public void QuitGame()
    {
        // �G�f�B�^��exe���ŏ����𕪊򂳂��悤
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
