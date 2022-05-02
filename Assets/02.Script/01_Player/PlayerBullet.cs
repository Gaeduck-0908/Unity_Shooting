using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_bullet : MonoBehaviour
{
    // TODO
    // 플레이어의 총알 관련 코드 작성바람 

    // 총알의 데미지
    public int Bullet_dmg_Lv1;
    public int Bullet_dmg_Lv2;
    public int Bullet_dmg_Lv3;
    public int Bullet_dmg_Lv4;
    public int Bullet_dmg_Lv5;

    // 총알의 스피드
    public float Bullet_Speed = 10.0f;

    // 화면밖으로 나갈시
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    // 총알의 충돌판정
    private void OnTriggerEnter2D(Collider2D col)
    {
        switch(col.tag)
        {
            default:
                Destroy(this.gameObject);
                break;
        }
    }
}
