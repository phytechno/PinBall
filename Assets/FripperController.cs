using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる (HingeJointというUnityEngineのクラスのインスタンスを作っている)
    private HingeJoint myHingeJoint;
    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;


    // Start is called before the first frame update
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();
        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
        
    }

    // Update is called once per frame
    void Update()
    {
            //左矢印キーかAキーを押した時左フリッパーを動かす
            if((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && tag == "LeftFripperTag"){
                SetAngle(this.flickAngle);
            }
            //右矢印キーかDキーを押した時右フリッパーを動かす
            if((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && tag == "RightFripperTag"){
                SetAngle(this.flickAngle);
            }
            //下矢印キーかSキーを押した時両フリッパーを動かす
            if((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && tag == "LeftFripperTag"){
                SetAngle(this.flickAngle);
            }
            if((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && tag == "RightFripperTag"){
                SetAngle(this.flickAngle);
            }

            //キーが離された時フリッパーを元に戻す
            if(Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag"){
                SetAngle(this.defaultAngle);
            }
            if(Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag"){
                SetAngle(this.defaultAngle);
            }
            if(Input.GetKeyUp(KeyCode.A) && tag == "LeftFripperTag"){
                SetAngle(this.defaultAngle);
            }
            if(Input.GetKeyUp(KeyCode.D) && tag == "RightFripperTag"){
                SetAngle(this.defaultAngle);
            }
            if(Input.GetKeyUp(KeyCode.DownArrow) && tag == "LeftFripperTag"){
                SetAngle(this.defaultAngle);
            }
            if(Input.GetKeyUp(KeyCode.DownArrow) && tag == "RightFripperTag"){
                SetAngle(this.defaultAngle);
            }
            if(Input.GetKeyUp(KeyCode.S) && tag == "LeftFripperTag"){
                SetAngle(this.defaultAngle);
            }
            if(Input.GetKeyUp(KeyCode.S) && tag == "RightFripperTag"){
                SetAngle(this.defaultAngle);
            }
        
    }
    //フリッパーの傾きを設定
    public void SetAngle (float angle){
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
