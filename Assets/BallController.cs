using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最小値
    private float visiblePosZ = -6.5f;
    //得点用変数の初期化
    private int score = 0;
    
    private GameObject gameoverText;//ゲームオーバを表示するテキスト
    private GameObject scoreText;//通常課題2、得点を表示するテキスト

    // Use this for initialization
    void Start()
    {
        this.gameoverText = GameObject.Find("GameOverText");//シーン中のGameOverTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");//通常課題2、シーン中のScoreTextオブジェクトを取得
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
        this.scoreText.GetComponent<Text>().text = string.Format("{0}", score);//通常課題2、ScoreTextに得点を表示

    }
    //通常課題3，4、ターゲットに衝突した時の得点の加算とターゲット毎の取得点数の設定
    void OnCollisionEnter(Collision collision)
    {
        //オブジェクトのtagを取得
        string tag = collision.gameObject.tag;
        
        //衝突したオブジェクトによって点数を加算
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