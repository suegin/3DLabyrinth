using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YukiToggleSwitchController : MonoBehaviour, ISwitch
{
    // このスイッチは、動かす対象がこれのオンオフ状態を見て動く

    // スイッチ(自分)がオンなのか
    public bool isOn { get; private set; } = false;

    // 自分のメッシュレンダラー
    private MeshRenderer m_meshRenderer;

    // エディタでオッケー
    [SerializeField]
    private Material m_offMaterial;
    [SerializeField]
    private Material m_onMaterial;
    // 一度オンにしたら、オフにできるか
    [SerializeField]
    private bool m_canTurnOff = false;

    // Start is called before the first frame update
    void Start()
    {
        m_meshRenderer = GetComponent<MeshRenderer>();
        ChangeSwitchState(isOn);
    }

    public void Interact()
    {
        if (isOn && !m_canTurnOff) return;

        // 状態フラグを反転する
        isOn = !isOn;
        ChangeSwitchState(isOn);
    }

    private void ChangeSwitchState(bool state)
    {
        // 引数の状態に応じてデータを変える
        if (isOn)
        {
            // オンの時の状態
            transform.localPosition = Vector3.zero;
            m_meshRenderer.material = m_onMaterial;
        }
        else
        {
            // オフの時の状態
            transform.localPosition = new Vector3(0, 2, 0);
            m_meshRenderer.material = m_offMaterial;
        }
    }

    // ボールでスイッチオン
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Interact();
        }
    }
}
