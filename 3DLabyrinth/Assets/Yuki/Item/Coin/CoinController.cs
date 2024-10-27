using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private Vector3 m_rotaSpeed = new Vector3(0.0f, 2.0f, 0.0f);

    // Update is called once per frame
    void Update()
    {
        // ‰ñ“]‚Æ‚©•‚—V‚Æ‚©
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
        // ‰¹‚ð–Â‚ç‚·
        CoinSEController.Play();
        // ƒRƒCƒ“‚ð‰ÁŽZ
        CoinNumberController.IncreaseCoin();

        Destroy(gameObject);
    }
}
