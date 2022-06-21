using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    //弾のスピード
    public float speed = 5;
    //自然消滅までのタイマー
    public float time = 2;
    //打ち出す感覚
    public float coolTime = 10;
    public Object enemyBullet;

    //進行方向
    protected Vector3 forward = new Vector3(0, 1, -10);
    //打ち出すときの角度
    protected Quaternion forwardAxis = Quaternion.identity;
    //RigidBody用変数
    protected Rigidbody rb;
    //Enemy変数
    protected GameObject enemy;

    


    // Start is called before the first frame update
    void Start()
    {
        //rigidbody変数を初期化
        rb = this.GetComponent<Rigidbody>();

        //生成時に進行方向を決める
        if (enemy != null)
        {
            forward = enemy.transform.forward;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //移動量を進行方向にスピード分だけ加える
        rb.velocity = forwardAxis * forward * speed;

        //空中に浮かないようにする
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        //期間制限が来たら自然消滅する
        time -= Time.deltaTime;

        if (time <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerBody")
        {
            Destroy(this.gameObject);
        }
    }

    public void SetCharacterObject(GameObject character)
    {
        //弾を打ち出したキャラクターの情報を受け取る
        this.enemy = character;
    }

    public void SetForwardAxis(Quaternion axis)
    {
        //設定された角度を受け取る
        this.forwardAxis = axis;
    }
}
