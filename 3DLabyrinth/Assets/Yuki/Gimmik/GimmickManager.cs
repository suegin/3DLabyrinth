using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickManager : MonoBehaviour
{
    // こんな名前だけど多重扉しかマネジメントしません

    // 毎フレーム設定したToggleStateを持つオブジェクトのbool値をみて動くようにしようか

    // Listチョー便利ぃ
    [SerializeField]
    List<ToggleState> m_observeObjects = new List<ToggleState>();

    // 操作するオブジェクト群
    Collider m_wallCollider;
    [SerializeField]
    List<YukiImpactSwitch> m_swiches = new List<YukiImpactSwitch>();

    bool m_clear = false;

    private void Start()
    {
        m_wallCollider = GameObject.Find("InvisibleWall").GetComponent<Collider>();
    }

    void Update()
    {
        // もうクリアしたなら実行しなくていいよ
        if (m_clear) return;

        if (CheckStates())
        {
            // 通れるようにする
            m_wallCollider.enabled = false;
            foreach (var obj in m_swiches)
            {
                // スイッチを機能しなくする
                obj.isActive = false;
            }
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
