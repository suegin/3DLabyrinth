// IEnumeratorが複数存在したので、こっちのほうがわかりやすいかなーっと　思いました
using ListCollection = System.Collections.Generic;
using Coroutine = System.Collections;
using UnityEngine;
using System.Runtime.CompilerServices;

public class YukiImpactSwitch : MonoBehaviour, ISwitch
{
    // トグルと違い、スイッチ自体がオンオフの状態をとらず、設定したオブジェクトのオンオフをいじる
    // これをインパクトスイッチと呼ぼう　

    [SerializeField]
    private ListCollection.List<ToggleState> m_objects = new ListCollection.List<ToggleState>();

    // 自身のメッシュレンダラー
    private Renderer m_renderer;

    private Material m_onMaterial;
    private Material m_offMaterial;
    [SerializeField]
    private AudioClip m_doorSE;

    // 操作できるかどうか
    public bool isActive = true;

    private void Start()
    {
        m_renderer = GetComponent<MeshRenderer>();
        // これはめんどいのでロード
        m_onMaterial = (Material)Resources.Load("DarkGreen");
        m_offMaterial = (Material)Resources.Load("Green");
    }

    // ボールが当たってもInteractを実行
    private void OnCollisionEnter(Collision collision)
    {
        if (!isActive) return;

        if (collision.gameObject.tag == "Ball")
        {
            Interact();
        }
    }

    public void Interact()
    {
        // アクティブなら
        if (!isActive) return;

        // このスイッチに指定されたすべてのオブジェクトのステートを反転
        foreach (var obj in m_objects)
        {
            obj.SetState(!obj.GetState(), m_doorSE);
        }

        // 色をじわっと変えて、元に戻す
        // やっぱりDOTWeenではできないのでコルーチンで
        StartCoroutine(ChangeColor(0.5f));
    }

    private Coroutine.IEnumerator ChangeColor(float time)
    {
        // 色を変える
        m_renderer.material = m_onMaterial;
        yield return new WaitForSeconds(time);
        m_renderer.material = m_offMaterial;
    }
}