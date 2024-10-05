using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YukiSwitchController : MonoBehaviour
{
    // スイッチ(自分)がオンなのか
    private bool m_isOn = false;

    // 自分のメッシュレンダラー
    private MeshRenderer m_meshRenderer;

    // エディタでオッケー
    [SerializeField]
    Material[] m_materials = new Material[2];

    // Start is called before the first frame update
    void Start()
    {
        m_meshRenderer = GetComponent<MeshRenderer>();
        ChangeSwitchState(m_isOn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interect()
    {
        // 状態フラグを反転する
        m_isOn = !m_isOn;
        ChangeSwitchState(m_isOn);
    }

    private void ChangeSwitchState(bool state)
    {
        // 引数の状態に応じてデータを変える
        if (m_isOn)
        {
            // オンの時の状態
            m_meshRenderer.material = m_materials[0];
            transform.localPosition += new Vector3(0, 2, 0);
        }
        else
        {
            // オフの時の状態
            m_meshRenderer.material = m_materials[1];
        }
    }
}
