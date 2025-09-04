using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("�v���C���[�̔\�͒l")]
    public float speed = 3.0f;
    public float jumpPower = 9.0f;

    [Header("�n�ʔ���̑Ώۃ��C���[")]
    public LayerMask groundLayer;

    Rigidbody2D rbody; //Player�ɂ��Ă���RigidBody2D���������߂̕ϐ�
    Animator animator; //Animator�R���|�[�l���g���������߂̕ϐ�

    float axisH; //���͂̕������L�����邽�߂̕ϐ�
 
    bool gojump = false; //���W�����v�t���O(�����l�͋U=false)
 
    bool onGround = false; //�n�ʂɂ��邩�ǂ����̔���i���遁true�j
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); //Player�ɂ��Ă���R���|�[�l���g�����擾

        animator = GetComponent<Animator>(); //Animator�ɂ��Ă���R���|�[�l���g�����擾
    }

    // Update is called once per frame
    void Update()
    {
        ////���������������̃L�[�������ꂽ��(�����Ȃ��Ă������͂���)
        //if (Input.GetAxisRaw("Horizontal") != 0)
        {
            //Verocity�̌��ƂȂ�l�̎擾�i1.0���������j
            axisH = Input.GetAxisRaw("Horizontal");

            if(axisH > 0)
            {
                //�E������
                transform.localScale = new Vector3(1,1,1);
            }
            else if(axisH < 0)
            {
                //��������
                transform.localScale = new Vector3(-1, 1, 1);
            }

            //GetButtonDown���\�b�h�������Ɏw�肵���{�^���������ꂽ��True�i�������l�̋t�j�ɂȂ�
            if (Input.GetButtonDown("Jump"))
            {
                Jump(); //Jump���\�b�h�̔���
            }
        }

        

    }

    //1�b�Ԃ�50��(50fps)�J��Ԃ��悤�ɐ��䂵�Ȃ���s���J��Ԃ����\�b�h
    void FixedUpdate()
    {
        //�n�ʔ�����T�[�N���L���X�g�ōs���Ă��̌��ʂ�ϐ�onGround�ɑ��
        onGround = Physics2D.CircleCast(
            transform.position,   //���ˈʒu���v���C���[�̈ʒu�i��_�j
            0.2f,                 //�T�[�N���L���X�g�̉~�̑傫���i���a�j
            new Vector2(0,1.0f),�@//���˕�����������
            0,                     //���ˋ���
            groundLayer       //�ΏۂƂȂ郌�C���[��� ��LayerMask�^
            );

        //velocity�ɒl����
        rbody.linearVelocity = new Vector2(axisH * speed, rbody.linearVelocity.y);

        //�W�����v�t���O����������
        if (gojump)
        {
            //�W�����v�����遨�v���C���[����ɉ����o��
            rbody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            gojump = false;
        }

        //if (onGround) //�n�ʂ̏�ɂ���Ƃ�
        //{
            if (axisH == 0) //���E��������Ă��Ȃ�
            {
                animator.SetBool("Run", false);�@//Idle�A�j���ɐ؂�ւ�
            }
            else //���E��������Ă���
            {
                animator.SetBool("Run", true);�@//Run�A�j���ɐ؂�ւ�
            }
        //}
    }

    //Jump��p�̃��\�b�h
    void Jump()
    {
        if (onGround)
        {
            gojump = true; //Jump�t���O��ON�ɂ���
            animator.SetTrigger("Jump");
        }
        
    }
}
