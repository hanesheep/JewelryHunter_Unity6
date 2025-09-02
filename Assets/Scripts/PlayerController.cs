using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody; //Player�ɂ��Ă���RigidBody2D���������߂̕ϐ�

    float axisH; //���͂̕������L�����邽�߂̕ϐ�
    public float speed = 3.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ////���������������̃L�[�������ꂽ��(�����Ȃ��Ă������͂���)
        //if (Input.GetAxisRaw("Horizontal") != 0)
        {
            //Verocity�̌��ƂȂ�l�̎擾�i1.0���������j
            axisH = Input.GetAxisRaw("Horizontal");

        }

    }

    //1�b�Ԃ�50��(50fps)�J��Ԃ��悤�ɐ��䂵�Ȃ���s���J��Ԃ����\�b�h
    private void FixedUpdate()
    {
        //velocity�ɒl����
        rbody.linearVelocity = new Vector2(axisH * speed, rbody.linearVelocity.y);

    }
}
