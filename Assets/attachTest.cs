using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TapCheck; //タッチテストで追記

public class attachTest : MonoBehaviour
{
    //タッチテストで追記
    //TouchManager touchManager;
    //Calc型の変数を定義
    Calc calc;
    FunctionTest functionTest; //public付けても同じ public付けたら、ここにないとエラー
    //GetTapInfo getTapInfo;
    TapCheck2 tapCheck2; //これを無くして、StartでTapCheck2 tapCheck2 = new TapCheck2();をやるとエラーになる★

    // Start is called before the first frame update
    void Start()
    {
        //タッチテストで追記
        //this.touchManager = new TouchManager();
        //this.getTapInfo = new GetTapInfo();
        this.tapCheck2 = new TapCheck2();

        if (Application.isEditor) {
            // エディタで実行中
            Debug.Log("エディタで実行中");
        } else {
            // 実機で実行中
            Debug.Log("実機で実行中");
        }

        //クラステスト
        calc = new Calc();
        //各計算を行う
        Debug.Log("Add:" + calc.Add(3, 4));
        Debug.Log("Sub:" + calc.Sub(5, 4));
        Debug.Log("Mul:" + calc.Mul(32, 41));
        Debug.Log("Div:" + calc.Add(10, 5));
        int result = calc.Add(10, 5);
        Debug.Log("Div:" + result);

        //関数テスト
        functionTest = new FunctionTest();
        string result2 = functionTest.Add(30, 20);
        Debug.Log("Div2:" + result2);

    }

    // Update is called once per frame
    void Update()
    {
        //string lrPos = getTapInfo.GetLrPos();
        //string lrPos = "";
        //string lrPos = tapCheck2.GetLrPos();
        //bool touchRight = tapCheck2.GetLrPos();

        bool[] resultArray = tapCheck2.GetLrPos();

        if(resultArray[0] && resultArray[1] == false) {
            Debug.Log("右フリッパーを動かす");
        }
        if(resultArray[1] && resultArray[0] == false) {
            Debug.Log("左フリッパーを動かす");
        }
        if(resultArray[0] && resultArray[1]) {
            Debug.Log("両方のフリッパーを動かす");
        }
        

        /*
        //タッチテストで追記
        //タッチ状態更新
        this.touchManager.update();
        //タッチ取得
        TouchManager touchState = this.touchManager.getTouch();

        //タッチされていたら処理
        if(touchState.touchFlg) {
            if (touchState.touchPhase == TouchPhase.Began) {
                // タッチした瞬間の処理
                Debug.Log("タッチされているので処理します");
                Debug.Log(touchState.touchPosition);
            }
            
        }
        */
        
        

        /*
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("クリックした瞬間");
        }

        if (Input.GetMouseButtonUp(0)) {
            Debug.Log("離した瞬間");
        }

        if (Input.GetMouseButton(0)) {
            Debug.Log("クリックしっぱなし");
        }
        */
        
    }

    
}
