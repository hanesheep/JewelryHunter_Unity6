using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("プレイヤーの能力値")]
    public float speed = 3.0f;
    public float jumpPower = 9.0f;

    [Header("地面判定の対象レイヤー")]
    public LayerMask groundLayer;

    Rigidbody2D rbody; //PlayerについているRigidBody2Dを扱うための変数
    Animator animator; //Animatorコンポーネントを扱うための変数

    float axisH; //入力の方向を記憶するための変数
 
    bool gojump = false; //←ジャンプフラグ(初期値は偽=false)
 
    bool onGround = false; //地面にいるかどうかの判定（いる＝true）
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); //Playerについているコンポーネント情報を取得

        animator = GetComponent<Animator>(); //Animatorについているコンポーネント情報を取得
    }

    // Update is called once per frame
    void Update()
    {
        ////もしも水平方向のキーが押されたら(書かなくても成立はする)
        //if (Input.GetAxisRaw("Horizontal") != 0)
        {
            //Verocityの元となる値の取得（1.0ｆずつ動く）
            axisH = Input.GetAxisRaw("Horizontal");

            if(axisH > 0)
            {
                //右を向く
                transform.localScale = new Vector3(1,1,1);
            }
            else if(axisH < 0)
            {
                //左を向く
                transform.localScale = new Vector3(-1, 1, 1);
            }

            //GetButtonDownメソッド→引数に指定したボタンが押されたらTrue（＝初期値の逆）になる
            if (Input.GetButtonDown("Jump"))
            {
                Jump(); //Jumpメソッドの発動
            }
        }

        

    }

    //1秒間に50回(50fps)繰り返すように制御しながら行う繰り返しメソッド
    void FixedUpdate()
    {
        //地面判定をサークルキャストで行ってその結果を変数onGroundに代入
        onGround = Physics2D.CircleCast(
            transform.position,   //発射位置＝プレイヤーの位置（基準点）
            0.2f,                 //サークルキャストの円の大きさ（半径）
            new Vector2(0,1.0f),　//発射方向※下方向
            0,                     //発射距離
            groundLayer       //対象となるレイヤー情報 ※LayerMask型
            );

        //velocityに値を代入
        rbody.linearVelocity = new Vector2(axisH * speed, rbody.linearVelocity.y);

        //ジャンプフラグがたったら
        if (gojump)
        {
            //ジャンプさせる→プレイヤーを上に押し出す
            rbody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            gojump = false;
        }

        //if (onGround) //地面の上にいるとき
        //{
            if (axisH == 0) //左右が押されていない
            {
                animator.SetBool("Run", false);　//Idleアニメに切り替え
            }
            else //左右が押されている
            {
                animator.SetBool("Run", true);　//Runアニメに切り替え
            }
        //}
    }

    //Jump専用のメソッド
    void Jump()
    {
        if (onGround)
        {
            gojump = true; //JumpフラグをONにする
            animator.SetTrigger("Jump");
        }
        
    }
}
