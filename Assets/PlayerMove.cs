using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //カメラから見た画面左下の座標を入れる変数
    Vector3 LeftBottom;
    //カメラから見た画面右下の座標を入れる変数
    Vector3 RightTop;
    //子オブジェクトのサイズを入れるための変数
    private float Left, Right, Top, Bottom;

    // Start is called before the first frame update
    void Start()
    {
        //カメラとプレイヤーの距離を測る（表示画面の四炭を設定するために必要）
        var distance = Vector3.Distance(Camera.main.transform.position, transform.position);
        //スクリーン画面左下の位置を設定する
        LeftBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        //スクリーン右上の位置を設定する
        RightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));
        foreach (Transform child in gameObject.transform)
        {
            //子オブジェクトの中で一番右の位置にいたなら
            if(child.localPosition.x >= Right)
            {
                //子オブジェクトのローカルx座標を右端用の変数に代入する
                Right = child.transform.localPosition.x;
            }
            //子オブジェクトの中で一番左いたなら
            if (child.localPosition.x <= Left)
            {
                //子オブジェクトのローカルx座標を左端用の変数に代入する
                Left = child.transform.localPosition.x;
            }
            //子オブジェクトの中で一番上いたなら
            if (child.localPosition.x >= Top)
            {
                //子オブジェクトのローカルx座標を上端用の変数に代入する
                Top = child.transform.localPosition.z;
            }
            //子オブジェクトの中で一番下いたなら
            if (child.localPosition.x <= Bottom)
            {
                //子オブジェクトのローカルx座標を下端用の変数に代入する
                Bottom = child.transform.localPosition.z;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーのワールド座標を取得
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
        //プレイヤーのワールド座標に代入
        transform.position = new Vector3(
            Mathf.Clamp(pos.x, LeftBottom.x + transform.localScale.x - Left, RightTop.x - transform.localScale.x - Right),
            pos.y,
            Mathf.Clamp(pos.z, LeftBottom.z + transform.localScale.z - Bottom, RightTop.z - transform.localScale.z - Top)
            );
    }
}
