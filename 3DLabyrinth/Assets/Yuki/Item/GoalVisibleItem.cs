using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalVisibleItem : Item
{
    // �擾�������莞�ԃS�[���̕������w�������I�u�W�F�N�g�𐶐�����
    // ����͐������邾���ŁA���̑��̋@�\�͐��������I�u�W�F�N�g������ɂ��@

    // �����K�����Ȃ��Ƃ�
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
        // ����
        Instantiate(_itemPrefab, _canvas.transform);
    }
}
