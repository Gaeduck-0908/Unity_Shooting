using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lib;

public class Enemy : Singleton<Enemy>
{
    public int hp;
    public int dmg;
    private float speed = 5.0f;

    private void Start()
    {
        hp = 20;
        dmg = 10;
    }

    private void Update()
    {
        move();
        StartCoroutine("HP_check");
    }

    private void move()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private IEnumerator HP_check()
    {
        if(hp <= 0)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            yield return new WaitForSeconds(.3f);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "Player_Bullet_1":
                hp -= PlayerBullet.Instance.Bullet_dmg_Lv1;
                break;
            case "Player_Bullet_2":
                hp -= PlayerBullet.Instance.Bullet_dmg_Lv2;
                break;
            case "Player_Bullet_3":
                hp -= PlayerBullet.Instance.Bullet_dmg_Lv3;
                break;
            case "Player_Bullet_4":
                hp -= PlayerBullet.Instance.Bullet_dmg_Lv4;
                break;
            case "Player_Bullet_5":
                hp -= PlayerBullet.Instance.Bullet_dmg_Lv5;
                break;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy (this.gameObject);
    }
}
