using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    //�e�̃X�s�[�h
    public float speed = 5;
    //���R���ł܂ł̃^�C�}�[
    public float time = 2;
    //�ł��o�����o
    public float coolTime = 10;
    public Object enemyBullet;

    //�i�s����
    protected Vector3 forward = new Vector3(0, 1, -10);
    //�ł��o���Ƃ��̊p�x
    protected Quaternion forwardAxis = Quaternion.identity;
    //RigidBody�p�ϐ�
    protected Rigidbody rb;
    //Enemy�ϐ�
    protected GameObject enemy;

    


    // Start is called before the first frame update
    void Start()
    {
        //rigidbody�ϐ���������
        rb = this.GetComponent<Rigidbody>();

        //�������ɐi�s���������߂�
        if (enemy != null)
        {
            forward = enemy.transform.forward;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //�ړ��ʂ�i�s�����ɃX�s�[�h������������
        rb.velocity = forwardAxis * forward * speed;

        //�󒆂ɕ����Ȃ��悤�ɂ���
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        //���Ԑ����������玩�R���ł���
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
        //�e��ł��o�����L�����N�^�[�̏����󂯎��
        this.enemy = character;
    }

    public void SetForwardAxis(Quaternion axis)
    {
        //�ݒ肳�ꂽ�p�x���󂯎��
        this.forwardAxis = axis;
    }
}