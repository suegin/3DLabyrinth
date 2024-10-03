using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowBall : MonoBehaviour
{
    private PlayerRayCaster m_playerRayCaster;
    // Start is called before the first frame update
    void Start()
    {
        // 自分のオブジェクトのコンポーネントを取得
        m_playerRayCaster = GetComponent<PlayerRayCaster>();
    }

    // Update is called once per frame
    void Update()
    {
        // 入力
    }
}
