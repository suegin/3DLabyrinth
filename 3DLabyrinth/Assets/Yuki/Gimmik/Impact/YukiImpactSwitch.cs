using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class YukiImpactSwitch : MonoBehaviour, ISwitch
{
    // トグルと違い、スイッチ自体がオンオフの状態をとらず、設定したオブジェクトのオンオフをいじる
    // これをインパクトスイッチと呼ぼう　

    [SerializeField]
    private List<ToggleState> m_objects = new List<ToggleState>(); 

    // 自身のメッシュレンダラー
    //private Renderer m_renderer;

    [SerializeField]
    private Material m_onMaterial;
    [SerializeField]
    private Material m_offMaterial;

    private void Start()
    {
        //m_renderer = GetComponent<MeshRenderer>();
    }

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

        // 自身の色を変えるアニメーション
        // 後回し
    }
}
