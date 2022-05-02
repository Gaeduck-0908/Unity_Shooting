using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Manager : MonoBehaviour
{
    // ���ȭ�� ���� �ڵ� �ۼ� �ٶ�

    // ���� Ÿ��
    [SerializeField]
    private Transform target;

    // ����� ����
    private float Range = 9.9f;

    // ����� ������ �ӵ�
    private float Speed = 3.0f;

    // ����� ����
    private Vector3 moveDir = Vector3.down;

    // �����Ӵ��� ����
    private void Update()
    {
        // �̵�
        transform.position += moveDir * Speed * Time.deltaTime;

        // ��ġ����
        if(transform.position.y <= -Range)
        {
            transform.position = target.position + Vector3.up * Range;
        }
    }
}