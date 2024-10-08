using System.Collections.Generic;
using UnityEngine;

public class YukiImpactSwitch : MonoBehaviour, ISwitch
{
    // トグルと違い、スイッチ自体がオンオフの状態をとらず、設定したオブジェクトのオンオフをいじる
    // これをインパクトスイッチと呼ぼう　

    [SerializeField]
    private List<ToggleState> m_objects = new List<ToggleState>(); 

    // ボールが当たってもInteractを実行
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Interact();
        }
    }

    public void Interact()
    {
        // このスイッチに指定されたすべてのオブジェクトのステートを反転
        foreach (var obj in m_objects)
        {
            obj.state = !obj.state;
        }

        // 自身のグラフィックをちょっとアニメーションする

        // 後回し
    }
}
