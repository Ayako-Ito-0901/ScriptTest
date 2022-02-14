using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapCheck2
{
    /*************
    タップされている場所を返すクラス
    **************/
    public bool touchFlg2; //タッチ有無
    public Vector2 touchPosition2; //タッチ座標
    public TouchPhase touchPhase2; //タッチ状態
    public bool touchLeft;
    public bool touchRight;

    /**************
    コンストラクタ ここの（）の意味を知りたい！なくてもいいかもなー
    ***************/
    public TapCheck2(bool flag = false, Vector2? position = null, TouchPhase phase = TouchPhase.Began) {
            
        this.touchFlg2 = flag;
        if(position == null) {
            this.touchPosition2 = new Vector2(0, 0);
        }
        else {
            this.touchPosition2 = (Vector2)position;
        }
        this.touchPhase2 = phase;
        this.touchLeft = false;
        this.touchRight = false;
    }
    
    /*************
    タップされた座標を確認し、bool型配列をリターンする{右側のタップ, 左側のタップ}
    **************/
    public bool[] GetLrPos() {
    
        this.touchFlg2 = false;
        this.touchLeft = false;
        this.touchRight = false;

        if (Input.touchCount > 0) {
            for(int i = 0; i <= Input.touchCount-1; i++) {
                Touch touch = Input.GetTouch(i);
                this.touchPosition2 = touch.position;
                this.touchPhase2 = touch.phase;
                this.touchFlg2 = true;                
                Debug.Log("タップ" + i + ":" + touch.position);
                if(this.touchPosition2.x >= 350) {
                    this.touchRight = true;
                }
                else {
                    this.touchLeft = true;
                }   
            }
        }
        
        bool[] resultArray = {this.touchRight, this.touchLeft};
        return resultArray;
        //return this.touchRight;
    }
}
