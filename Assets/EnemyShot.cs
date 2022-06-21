using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public Object enemyBullet;
    public int coolTime;
    // Start is called before the first frame update
    void Start()
    {
        coolTime = 500;
    }

    // Update is called once per frame
    void Update()
    {
        coolTime -= 1;
        if (coolTime <= 0)
        {
            coolTime = 300;
            //’e‚ð¶¬‚·‚é
            Instantiate(enemyBullet, transform.position, Quaternion.identity);
        }
    }




}
