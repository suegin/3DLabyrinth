using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ��]�Ƃ����V�Ƃ�
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
        GetComponent<AudioSource>().Play();
    }
}
