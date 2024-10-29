using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ToggleState : MonoBehaviour
{
    // オンオフを持つオブジェクトにアタッチして、
    // 状態をこれに記録。　
    // インパクトスイッチがこれを参照。　

    private bool state;

    public void SetState(bool value)
    {
        state = value;
    }

    public void SetState(bool value, AudioClip se)
    {
        state = value;

        // ここで音を鳴らす
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
