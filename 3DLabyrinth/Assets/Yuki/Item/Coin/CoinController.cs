using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private Vector3 m_rotaSpeed = new Vector3(0.0f, 2.0f, 0.0f);
    [SerializeField]
    private AudioClip m_clip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 回転とか浮遊とか
        transform.Rotate(m_rotaSpeed, Space.World);
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
        SEGenerator.GenerateSEAtPoint(transform.position, m_clip, 0.1f);
        // コインを加算
        CoinNumberController.IncreaseCoin();

        Destroy(gameObject);
    }
}
