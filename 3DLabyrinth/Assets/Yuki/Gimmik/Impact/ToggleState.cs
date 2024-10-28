using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ToggleState : MonoBehaviour
{
    // �I���I�t�����I�u�W�F�N�g�ɃA�^�b�`���āA
    // ��Ԃ�����ɋL�^�B�@
    // �C���p�N�g�X�C�b�`��������Q�ƁB�@

    private bool state;

    [SerializeField]
    private AudioClip se;

    public void SetState(bool value)
    {
        state = value;

        // �����ŉ���炷
        AudioSource.PlayClipAtPoint(se, transform.position);
    }

    public bool GetState()
    {
        return state;
    }
}
