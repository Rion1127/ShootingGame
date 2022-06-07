using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //�J�������猩����ʍ����̍��W������ϐ�
    Vector3 LeftBottom;
    //�J�������猩����ʉE���̍��W������ϐ�
    Vector3 RightTop;
    //�q�I�u�W�F�N�g�̃T�C�Y�����邽�߂̕ϐ�
    private float Left, Right, Top, Bottom;

    // Start is called before the first frame update
    void Start()
    {
        //�J�����ƃv���C���[�̋����𑪂�i�\����ʂ̎l�Y��ݒ肷�邽�߂ɕK�v�j
        var distance = Vector3.Distance(Camera.main.transform.position, transform.position);
        //�X�N���[����ʍ����̈ʒu��ݒ肷��
        LeftBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        //�X�N���[���E��̈ʒu��ݒ肷��
        RightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));
        foreach (Transform child in gameObject.transform)
        {
            //�q�I�u�W�F�N�g�̒��ň�ԉE�̈ʒu�ɂ����Ȃ�
            if(child.localPosition.x >= Right)
            {
                //�q�I�u�W�F�N�g�̃��[�J��x���W���E�[�p�̕ϐ��ɑ������
                Right = child.transform.localPosition.x;
            }
            //�q�I�u�W�F�N�g�̒��ň�ԍ������Ȃ�
            if (child.localPosition.x <= Left)
            {
                //�q�I�u�W�F�N�g�̃��[�J��x���W�����[�p�̕ϐ��ɑ������
                Left = child.transform.localPosition.x;
            }
            //�q�I�u�W�F�N�g�̒��ň�ԏア���Ȃ�
            if (child.localPosition.x >= Top)
            {
                //�q�I�u�W�F�N�g�̃��[�J��x���W����[�p�̕ϐ��ɑ������
                Top = child.transform.localPosition.z;
            }
            //�q�I�u�W�F�N�g�̒��ň�ԉ������Ȃ�
            if (child.localPosition.x <= Bottom)
            {
                //�q�I�u�W�F�N�g�̃��[�J��x���W�����[�p�̕ϐ��ɑ������
                Bottom = child.transform.localPosition.z;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[�̃��[���h���W���擾
        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += 0.01f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= 0.01f;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            pos.z += 0.01f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            pos.z -= 0.01f;
        }
        //�v���C���[�̃��[���h���W�ɑ��
        transform.position = new Vector3(
            Mathf.Clamp(pos.x, LeftBottom.x + transform.localScale.x - Left, RightTop.x - transform.localScale.x - Right),
            pos.y,
            Mathf.Clamp(pos.z, LeftBottom.z + transform.localScale.z - Bottom, RightTop.z - transform.localScale.z - Top)
            );
    }
}
