using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lib;

public class EnemyManager : Singleton<EnemyManager>
{
    // TODO
    // 적군 생성 관련 코드 작성바람

    [SerializeField]
    GameObject[] Enemy;

    public int Enemy_death_count;
    private bool Boss_Spawn_check;

    void Start()
    {
        Boss_Spawn_check = false;
        Enemy_death_count = 25;
        InvokeRepeating("Enemy_Spawn", 3f, 2f);
    }

    public void Enemy_Spawn()
    {
        float randomPos = Random.Range(-2.5f, 2.5f);
        float random = Random.Range(0, Enemy.Length - 1);

        if (Enemy_death_count <= 29)
        {
            Instantiate(Enemy[(int)random], new Vector3(randomPos, 8, 0), transform.rotation);
        }
        else if (Enemy_death_count == 30)
        {
            Boss_Spawn();
        }
        Debug.Log(Enemy_death_count);
    }

    public void Boss_Spawn()
    {
        /*if (Enemy_death_count == 30 && Boss_Spawn_check == false)
        {
            Instantiate("보스", new Vector3(0, 8, 0), transform.rotation);
            Boss_Spawn_check = true;
        }*/
    }
}
