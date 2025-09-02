using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody; //PlayerについているRigidBody2Dを扱うための変数

    float axisH; //入力の方向を記憶するための変数
    public float speed = 3.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ////もしも水平方向のキーが押されたら(書かなくても成立はする)
        //if (Input.GetAxisRaw("Horizontal") != 0)
        {
            //Verocityの元となる値の取得（1.0ｆずつ動く）
            axisH = Input.GetAxisRaw("Horizontal");

        }

    }

    //1秒間に50回(50fps)繰り返すように制御しながら行う繰り返しメソッド
    private void FixedUpdate()
    {
        //velocityに値を代入
        rbody.linearVelocity = new Vector2(axisH * speed, rbody.linearVelocity.y);

    }
}
