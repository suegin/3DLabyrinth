using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEGenerator : MonoBehaviour
{
    private static GameObject s_SEObject;

    private void Start()
    {
        s_SEObject = (GameObject)Resources.Load("PointSEObject");
    }

    public static GameObject GenerateSEAtPoint(Vector3 worldPosition, AudioClip clip)
    {
        // 生成して効果音入れて鳴らす AudioSource.PlayClipAtPoint()がミキサーに対応していないため
        GameObject se = Instantiate(s_SEObject, worldPosition, Quaternion.identity);
        AudioSource source = se.GetComponent<AudioSource>();
        source.clip = clip;
        source.Play();
        // 後でいろいろしたいかもしれないのでゲームオブジェクトを返す
        return se;
    }

    /// <summary>
    /// volumeは0~1の範囲で頼む
    /// </summary>
    /// <param name="worldPosition"></param>
    /// <param name="clip"></param>
    /// <param name="volume"></param>
    /// <returns></returns>
    public static GameObject GenerateSEAtPoint(Vector3 worldPosition, AudioClip clip, float volume)
    {
        // 生成して効果音入れて鳴らす AudioSource.PlayClipAtPoint()がミキサーに対応していないため
        GameObject se = Instantiate(s_SEObject, worldPosition, Quaternion.identity);
        AudioSource source = se.GetComponent<AudioSource>();
        source.clip = clip;
        source.volume = Mathf.Clamp01(volume);
        source.Play();
        // 後でいろいろしたいかもしれないのでゲームオブジェクトを返す
        return se;
    }
}
