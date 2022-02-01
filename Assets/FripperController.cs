using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJoint�R���|�[�l���g������
    private HingeJoint myHingeJoint;

    //�����̌X��
    private float defaultAngle = 20;
    //�e�������̌X��
    private float flickAngle = -20;

    // Use this for initialization
    void Start()
    {
        //HingeJoint�R���|�[�l���g�擾
        this.myHingeJoint = GetComponent<HingeJoint>();

        //�t���b�p�[�̌X����ݒ�
        SetAngle(this.defaultAngle);

        //��ʉ����m�F���Ɏg�pDebug.Log("Screen Width : " + Screen.width);
    }

    // Update is called once per frame
    void Update()
    {

        //�����L�[�������������t���b�p�[�𓮂���
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //�E���L�[�����������E�t���b�p�[�𓮂���
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //���L�[�����ꂽ���t���b�p�[�����ɖ߂�
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        //���W�ۑ�F�X�}�[�g�t�H���ł���������悤�Ƀ}���`�^�b�`�ɑΉ�
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                //��ʍ������^�b�v���������t���b�p�[�𓮂���
                if (touch.phase == TouchPhase.Began && touch.position.x <= 540 && tag == "LeftFripperTag")
                {
                    SetAngle(this.flickAngle);
                }
                //��ʉE�����^�b�v�������E�t���b�p�[�𓮂���
                if (touch.phase == TouchPhase.Began && touch.position.x > 540 && tag == "RightFripperTag")
                {
                    SetAngle(this.flickAngle);
                }
                //��ʂ���w�����ꂽ���t���b�p�[�����ɖ߂�
                if (touch.phase == TouchPhase.Ended && tag == "LeftFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }
                if (touch.phase == TouchPhase.Ended && tag == "RightFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }
            }
        }    
    }




    //�t���b�p�[�̌X����ݒ�
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}