using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSEController : MonoBehaviour
{
    private AudioSource m_audioSource;

    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    // SEÇ™Ç»ÇËèIÇÌÇ¡ÇΩÇÁè¡Ç¶ÇÈÇÊÇ§Ç…ÇµÇΩÇ¢
    private void Update()
    {
        if (m_audioSource.isPlaying) return;

        Destroy(gameObject);
    }
}
