using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private Vector3 m_rotaSpeed = new Vector3(0.0f, 500.0f, 0.0f);
    private static GameObject s_particle;

    private void Start()
    {
        s_particle = (GameObject)Resources.Load("Basic Hit");
    }

    // Update is called once per frame
    void Update()
    {
        // 回転とか浮遊とか
        transform.Rotate(m_rotaSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Gain();
        }
    }

    private void Gain()
    {
        // 音を鳴らす
        CoinSEController.Play();
        // コインを加算
        CoinNumberController.IncreaseCoin();

        // パーティクル
        Instantiate(s_particle, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
