using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Manager : MonoBehaviour
{
    // 배경화면 관련 코드 작성 바람

    // 따라갈 타겟
    [SerializeField]
    private Transform target;

    // 배경의 범위
    private float Range = 9.9f;

    // 배경이 움직일 속도
    private float Speed = 3.0f;

    // 진행될 방향
    private Vector3 moveDir = Vector3.down;

    // 프레임단위 실행
    private void Update()
    {
        // 이동
        transform.position += moveDir * Speed * Time.deltaTime;

        // 위치변경
        if(transform.position.y <= -Range)
        {
            transform.position = target.position + Vector3.up * Range;
        }
    }
}