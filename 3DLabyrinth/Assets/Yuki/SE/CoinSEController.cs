using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ƒRƒCƒ“‚ÌSE‚ª‘½d‚É‚È‚Á‚Ä‚¤‚é‚³‚©‚Á‚½‚Ì‚Å
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
