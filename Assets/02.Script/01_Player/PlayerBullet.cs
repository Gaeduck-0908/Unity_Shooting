using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // TODO
    // 플레이어의 총알 관련 코드 작성바람 

    // 총알의 데미지
    public int Bullet_dmg_Lv1 = 5;
    public int Bullet_dmg_Lv2 = 10;
    public int Bullet_dmg_Lv3 = 20;
    public int Bullet_dmg_Lv4 = 50;
    public int Bullet_dmg_Lv5 = 100;

    // 총알의 스피드
    public float Bullet_Speed = 10.0f;

    // 프레임단위 실행
    private void Update()
    {
        Bullet_move();
    }

    // 총알 움직임
    private void Bullet_move()
    {
        transform.Translate(Vector3.up * Bullet_Speed * Time.deltaTime);
    }

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
            case "Enemy":
                Destroy(this.gameObject);
                break;
        }
    }
}
