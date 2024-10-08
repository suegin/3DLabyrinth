using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ToggleState : MonoBehaviour
{
    // オンオフを持つオブジェクトにアタッチして、
    // 状態をこれに記録。　
    // インパクトスイッチがこれを参照。　

    public bool state;
}
