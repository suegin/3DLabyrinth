using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YukiSwitchController : MonoBehaviour
{
    // スイッチ(自分)がオンなのか
    public bool isOn { get; private set; } = false;

    // 自分のメッシュレンダラー
    private MeshRenderer m_meshRenderer;

    // エディタでオッケー
    [SerializeField]
    private Material[] m_materials = new Material[2];

    // Start is called before the first frame update
    void Start()
    {
        m_meshRenderer = GetComponent<MeshRenderer>();
        ChangeSwitchState(isOn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interect()
    {
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
            m_meshRenderer.material = m_materials[0];
        }
        else
        {
            // オフの時の状態
            transform.localPosition = new Vector3(0, 2, 0);
            m_meshRenderer.material = m_materials[1];
        }
    }
}
