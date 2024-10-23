using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CoinNumberController : MonoBehaviour
{
    public static CoinNumberController s_instance;
    private static int s_coinNumber;

    private void Awake()
    {
        if (s_instance != null)
        {
            Destroy(gameObject);
        }

        s_instance = this;
    }

    public static void IncreaseCoin()
    {
        s_coinNumber++;
        CoinText.SetTextNum(s_coinNumber);
    }
}
