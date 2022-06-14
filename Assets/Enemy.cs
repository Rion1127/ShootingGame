using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Enemy‚Ì‘Ì—Í
    public int enemyHp;



    // Start is called before the first frame update
    void Start()
    {
        //¶¬‚É‘Ì—Í‘cw’è‚µ‚Ä‚¨‚­
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
