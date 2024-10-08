using System.Collections.Generic;
using UnityEngine;

public class InvisibleWall : MonoBehaviour
{
    // 毎フレーム設定したToggleStateを持つオブジェクトのbool値をみて動くようにしようか

    // Listチョー便利ぃ
    [SerializeField]
    List<ToggleState> m_observeObjects = new List<ToggleState>();

    bool m_clear = false;

    void Update()
    {
        // もうクリアしたなら実行しなくていいよ
        if (m_clear) return;

        if (CheckStates())
        {
            // 通れるようにする
            GetComponent<Collider>().enabled = false;
            m_clear = true;
        }
    }

    private bool CheckStates()
    {
        // 全部trueならtrueを吐く
        bool result = true;
        foreach (var obj in m_observeObjects)
        {
            result &= obj.state;
        }
        return result;
    }
}
