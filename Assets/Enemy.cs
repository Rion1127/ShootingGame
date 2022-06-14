using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Enemyの体力
    public int enemyHp;



    // Start is called before the first frame update
    void Start()
    {
        //生成時に体力祖指定しておく
        enemyHp = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Damage()
    {
        enemyHp = enemyHp - 1;
        Debug.Log(enemyHp);
    }
}
