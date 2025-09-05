using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject mainImage;   //�A�i�E���X������摜
    public GameObject buttonPanel; //�{�^�����O���[�v�����Ă���p�l��

    public GameObject retryButton; //���g���C�{�^��
    public GameObject nextButton;  //�l�N�X�g�{�^��

    public Sprite gameClearSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonPanel.SetActive(false); //���݂��\��

        //���ԍ��Ń��\�b�h�𔭓�
        Invoke("InactiveImage", 1.0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameState == "gameClear") 
        {
            buttonPanel.SetActive(true); //�{�^���p�l���̕���
            mainImage.SetActive(true);�@ //���C���摜�̕���
            //���C���摜�I�u�W�F�N�g��Image�R���|�[�l���g���������Ă���ϐ�sprite�ɃX�e�[�W�N���A�̊G����
            mainImage.GetComponent<Image>().sprite = gameClearSprite;
            //���g���C�{�^���I�u�W�F�N�g��Button�R���|�[�l���g���������Ă���ϐ�interactible�𖳌��i�{�^���@�\�𖳌��j
            retryButton.GetComponent<Button>().interactable = false;
        }
    }

    //���C���摜���\���ɂ��邽�߂����̃��\�b�h
    void InactiveImage()
    {
        mainImage.SetActive(false);
    }
}
