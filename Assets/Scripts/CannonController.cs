using UnityEngine;

public class CannonController : MonoBehaviour
{
    [Header("生成プレハブ/時間/速度/範囲")]
    public GameObject objPrefab;　　//発生させるPrefabデータ
    public float delayTime = 3.0f; //遅延時間
    public float fireSpeed = 4.0f; //発射速度
    public float length = 8.0f;     //範囲

    [Header("発射口")]
    public Transform gateTransform;

    GameObject player;　　　　　　　//プレイヤー
    float passedTime = 0;          //経過時間


    //距離チェック
    bool CheckLength(Vector2 targetPos)
    {
        bool ret = false;
        float d = Vector2.Distance(transform.position, targetPos);
        if (d > 0)
        {
            ret = true;
        }
        return ret;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //プレイヤーを見つける
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        //待機時間を加算
        passedTime = Time.deltaTime;

        //Playerとの距離をチェック
        if (CheckLength(player.transform.position))
        {
            //待機時間経過
            if(passedTimes > delayTime)
            {
                passedTimes = 0;　　　　//0にリセット
                //砲弾をプレハブから作る
                Vector2 pos = new Vector2(gateTransform.position.x, gateTransform.position.y);
                GameObject obj = Instantiate(objPrefab, pos, Quaternion.identity);

                //砲身が向いている方向に発射する
                Rigidbody2D rbody = obj.GetComponent<Rigidbody2D>();
                float angleZ = transform.localEulerAngles.z;
                float x = Mathf.Cos(angleZ * Mathf.Deg2Rad);
                float y = Mathf.Sin(angleZ * Mathf.Deg2Rad);
                Vector2 v = new Vector2(x, y) * fireSpeed;
                rbody.AddForce(v, ForceMode2D.Impulse);

            }
        }

    }
}
