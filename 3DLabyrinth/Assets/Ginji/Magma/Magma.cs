using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magma : MonoBehaviour
{
    GameObject player;
    GameObject ball;
    [SerializeField]
    Vector3 transPos = new Vector3(0, 0, 0);
    [SerializeField]
    private AudioClip m_burnSE;
    private FadeOut m_fadeOut;

    private void Start()
    {
        player = GameObject.Find("Player");
        ball = GameObject.Find("Ball");
        m_fadeOut = GameObject.Find("FadeManager").GetComponent<FadeOut>();
    }
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Burning());
        }

        if(collision.gameObject.CompareTag("Ball"))
        {
            collision.transform.position = transPos;
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    private IEnumerator Burning()
    {
        // プレイヤーを止める
        // やっぱり代入は命令している感じがしないので関数を作るのは大事ネ
        // あと複数行にまたがったりするからネ
        LookMove.SetCanMove(false);
        player.GetComponent<PlayerMove>().KillVelocityStop();

        // 効果音を鳴らす
        SEGenerator.GenerateSEAtPoint(transform.position, m_burnSE);
        // フェードアウト
        yield return YukiFadeManager.FadeOut(2.0f);
        // プレイヤーの座標の移動
        player.transform.position = transPos;
        // フェードイン
        yield return YukiFadeManager.FadeIn(0.5f);

        // プレイヤーの動き制限解除
        LookMove.SetCanMove(true);
        player.GetComponent<PlayerMove>().Resume();
    }
}
