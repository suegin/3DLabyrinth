using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ToggleState : MonoBehaviour
{
    // オンオフを持つオブジェクトにアタッチして、
    // 状態をこれに記録。　
    // インパクトスイッチがこれを参照。　

    private bool state;

    [SerializeField]
    private AudioClip se;

    public void SetState(bool value)
    {
        state = value;

        // ここで音を鳴らす
        AudioSource.PlayClipAtPoint(se, transform.position);
    }

    public bool GetState()
    {
        return state;
    }
}
