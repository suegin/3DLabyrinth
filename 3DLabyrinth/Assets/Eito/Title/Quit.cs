using UnityEngine;

public class Quit : MonoBehaviour
{
    // �Q�[�����~�߂鏈�����{�^���ɒ񋟂��邾��
    public void QuitGame()
    {
        // �G�f�B�^��exe���ŏ����𕪊򂳂��悤
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
