using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    public FadeOut fadeOut;
    private void Start()
    {
        
    }

    //ゲームオブジェクトに当たったとき
    private void Update()
    {
        if (fadeOut.isFade)
        {
            SceneManager.LoadScene("Eito/Scene/ClearScene");    //クリアシーンに遷移
            Debug.Log("clear");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //当たったゲームオブジェクトがPlayerタグだったとき
        if (collision.gameObject.CompareTag("Player"))
        {
            fadeOut.ChangeScene();
        }
    }
}
