using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YukiToggleDoor : MonoBehaviour
{
    // エディタで関連づけるスイッチを指定
    [SerializeField]
    private List< YukiToggleSwitchController> m_switches = new List<YukiToggleSwitchController>();

    private Vector3 m_speed = new Vector3(0, 1, 0);

    private Vector3 m_initPos;

    private void Start()
    {
        // 最初の自分の位置
        m_initPos = transform.position;
    }

    void FixedUpdate()
    {
        // オンオフで処理を変える
        if (CheckSwitches())
        {
            // 範囲に収める
            if (transform.position.y < m_initPos.y + 7)
            {
                transform.Translate(m_speed * Time.fixedDeltaTime);
            }
        }
        else
        {
            if (transform.position.y > m_initPos.y)
            {
                transform.Translate(-m_speed * Time.fixedDeltaTime);
            }
        }
    }

    private bool CheckSwitches()
    {
        // リストの全スイッチを見て一つでもオンなら恩を返す
        foreach(var sw in m_switches)
        {
            if (sw.isOn)
            {
                return true;
            }
        }
        return false;
    }
}
