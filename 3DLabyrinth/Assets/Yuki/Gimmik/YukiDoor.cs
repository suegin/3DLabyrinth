using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YukiDoor : MonoBehaviour
{
    // エディタで関連づけるスイッチを指定
    [SerializeField]
    private List< YukiSwitchController> m_switches = new List<YukiSwitchController>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        // オンオフで処理を変える
        if (CheckSwitches())
        {

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
