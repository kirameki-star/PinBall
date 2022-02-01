using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //�{�[����������\���̂���z���̍ŏ��l
    private float visiblePosZ = -6.5f;
    //���_�p�ϐ��̏�����
    private int score = 0;
    
    private GameObject gameoverText;//�Q�[���I�[�o��\������e�L�X�g
    private GameObject scoreText;//�ʏ�ۑ�2�A���_��\������e�L�X�g

    // Use this for initialization
    void Start()
    {
        this.gameoverText = GameObject.Find("GameOverText");//�V�[������GameOverText�I�u�W�F�N�g���擾
        this.scoreText = GameObject.Find("ScoreText");//�ʏ�ۑ�2�A�V�[������ScoreText�I�u�W�F�N�g���擾
    }

    // Update is called once per frame
    void Update()
    {
        //�{�[������ʊO�ɏo���ꍇ
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverText�ɃQ�[���I�[�o��\��
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
        this.scoreText.GetComponent<Text>().text = string.Format("{0}", score);//�ʏ�ۑ�2�AScoreText�ɓ��_��\��

    }
    //�ʏ�ۑ�3�C4�A�^�[�Q�b�g�ɏՓ˂������̓��_�̉��Z�ƃ^�[�Q�b�g���̎擾�_���̐ݒ�
    void OnCollisionEnter(Collision collision)
    {
        //�I�u�W�F�N�g��tag���擾
        string tag = collision.gameObject.tag;
        
        //�Փ˂����I�u�W�F�N�g�ɂ���ē_�������Z
        if (tag == "SmallStarTag")
        {
            score += 10;

        }
        else if (tag == "LargeStarTag")
        {
            score += 30;

        }
        else if (tag == "SmallCloudTag")
        {
            score += 20;

        }
        else if (tag == "LargeCloudTag")
        {
            score += 40;
        }
        
    }

}