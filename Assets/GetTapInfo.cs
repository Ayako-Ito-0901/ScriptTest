using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TapCheck; //タッチテストで追記

public class GetTapInfo
{
    //タッチテストで追記
    TouchManager touchManager;

    public string GetLrPos() {

        this.touchManager = new TouchManager();
        this.touchManager.update();
        TouchManager touchState = this.touchManager.getTouch();

        //タッチされていたら処理
        if(touchState.touchFlg) {
            if (touchState.touchPhase == TouchPhase.Began) {
                // タッチした瞬間の処理
                Debug.Log("GetTapInfoよりタッチされているので処理します");
                Debug.Log(touchState.touchPosition);
                Debug.Log("X軸のみ：" + touchState.touchPosition.x);

                if(touchState.touchPosition.x >= 350) {
                    return "Right";
                }
                else {
                    return "Left";
                }
            }
            else {
                return "";
            }
            
        }
        else {
            return "";
        }

    }
    
}
