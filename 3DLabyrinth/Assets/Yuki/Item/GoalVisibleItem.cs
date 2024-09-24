using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalVisibleItem : Item
{
    // 取得したら一定時間ゴールの方向を指し示すオブジェクトを生成する
    // これは生成するだけで、その他の機能は生成したオブジェクトが勝手にやる　

    // 命名規則つけないとな
    [SerializeField]
    private GameObject _itemPrefab;
    private GameObject _canvas;
    void Start()
    {
        _canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void ItemGet()
    {
        // 生成
        Instantiate(_itemPrefab, _canvas.transform);
    }
}
