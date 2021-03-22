using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    // ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;
    // ゲームオーバーを表示するテキスト
    private GameObject gameoverText;
    // スコア数値を表示するテキスト
    private GameObject scoreNum;
    // 得点値を初期化
    private int score = 0;

    void Start(){
        // シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        // シーン中のScoreNumオブジェクトを取得
        this.scoreNum = GameObject.Find("ScoreNum");
    }

    void Update(){
        // ボールが画面外に出た場合
        if(this.transform.position.z < this.visiblePosZ){
            //GameOverTestにゲームオーバーを表示
            this.gameoverText.GetComponent<Text> ().text = "Game Over";
        }
        // スコアを毎フレーム更新
        this.scoreNum.GetComponent<Text> ().text = score.ToString();
    }

    // ボール衝突時のイベント
    void OnCollisionEnter(Collision collision){
        // ボールが衝突した時に得点を加算
        switch(collision.gameObject.tag){
            case "SmallStarTag":
                score += 1;
                break;
            case "LargeStarTag":
                score += 10;
                break;
            case "SmallCloudTag":
                score += 50;
                break;
            case "LargeCloudTag":
                score += 1000;
                break;
        }
    }
}
