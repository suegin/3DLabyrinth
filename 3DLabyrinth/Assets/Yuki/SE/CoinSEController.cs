using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �R�C����SE�����d�ɂȂ��Ă��邳�������̂�
public class CoinSEController : MonoBehaviour
{
    private static AudioSource m_se;

    private void Start()
    {
        m_se = GetComponent<AudioSource>();
    }

    public static void Play()
    {
        m_se.Play();
    }
}
