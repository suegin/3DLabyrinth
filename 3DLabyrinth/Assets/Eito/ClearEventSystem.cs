using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClearEventSystem : MonoBehaviour
{
    // 一定時間後にボタンにフォーカスする
    [SerializeField]
    private GameObject m_button;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FacusOnButton(2.0f));
    }

    private IEnumerator FacusOnButton(float time)
    {
        yield return new WaitForSeconds(time);
        EventSystem.current.SetSelectedGameObject(m_button);
    }
}
