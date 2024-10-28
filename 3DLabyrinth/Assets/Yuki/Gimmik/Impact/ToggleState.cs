using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ToggleState : MonoBehaviour
{
    // �I���I�t�����I�u�W�F�N�g�ɃA�^�b�`���āA
    // ��Ԃ�����ɋL�^�B�@
    // �C���p�N�g�X�C�b�`��������Q�ƁB�@

    private bool state;

    public void SetState(bool value)
    {
        state = value;
    }

    public void SetState(bool value, AudioClip se)
    {
        state = value;

        // �����ŉ���炷
        AudioSource source = GetComponent<AudioSource>();
        if (source != null)
        {
            source.clip = se;
            source.Play();
        }
    }

    public bool GetState()
    {
        return state;
    }
}
