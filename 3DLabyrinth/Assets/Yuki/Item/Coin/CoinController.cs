using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private Vector3 m_rotaSpeed = new Vector3(0.0f, 2.0f, 0.0f);

    // Update is called once per frame
    void Update()
    {
        // ��]�Ƃ����V�Ƃ�
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
        // ����炷
        CoinSEController.Play();
        // �R�C�������Z
        CoinNumberController.IncreaseCoin();

        Destroy(gameObject);
    }
}
