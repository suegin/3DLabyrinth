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
        // �������Č��ʉ�����Ė炷 AudioSource.PlayClipAtPoint()���~�L�T�[�ɑΉ����Ă��Ȃ�����
        GameObject se = Instantiate(s_SEObject, worldPosition, Quaternion.identity);
        AudioSource source = se.GetComponent<AudioSource>();
        source.clip = clip;
        source.Play();
        // ��ł��낢�낵������������Ȃ��̂ŃQ�[���I�u�W�F�N�g��Ԃ�
        return se;
    }

    /// <summary>
    /// volume��0~1�͈̔͂ŗ���
    /// </summary>
    /// <param name="worldPosition"></param>
    /// <param name="clip"></param>
    /// <param name="volume"></param>
    /// <returns></returns>
    public static GameObject GenerateSEAtPoint(Vector3 worldPosition, AudioClip clip, float volume)
    {
        // �������Č��ʉ�����Ė炷 AudioSource.PlayClipAtPoint()���~�L�T�[�ɑΉ����Ă��Ȃ�����
        GameObject se = Instantiate(s_SEObject, worldPosition, Quaternion.identity);
        AudioSource source = se.GetComponent<AudioSource>();
        source.clip = clip;
        source.volume = Mathf.Clamp01(volume);
        source.Play();
        // ��ł��낢�낵������������Ȃ��̂ŃQ�[���I�u�W�F�N�g��Ԃ�
        return se;
    }
}
