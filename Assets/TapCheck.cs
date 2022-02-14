using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//namespace TapCheck {

    public class TouchManager {
        /*************
        タップされている場所を返すクラス
        **************/
        public bool touchFlg; //タッチ有無
        public Vector2 touchPosition; //タッチ座標
        public TouchPhase touchPhase; //タッチ状態
        
        /**
         * コンストラクタ（インスタンスを作成したタイミングで実行されるメソッド）
         * クラス名と同じ名前にする必要がある。戻り値は返せない。（）の意味を知りたい★
         * @param bool flag タッチ有無
         * @param Vector2 position タッチ座標(引数の省略が行えるようにNull許容型に)
         * @param Touchphase phase タッチ状態
         * @access public
         */
        public TouchManager(bool flag = false, Vector2? position = null, TouchPhase phase = TouchPhase.Began) {
            
            this.touchFlg = flag;
            if(position == null) {
                this.touchPosition = new Vector2(0, 0);
            }
            else {
                this.touchPosition = (Vector2)position;
            }
            this.touchPhase = phase;
        }

        /*************
        更新
        **************/
        public void update() {
            this.touchFlg = false;

            //エディタ
            if(Application.isEditor) {
                /*
                for(int i = 0; i <= Input.touchCount-1; i++) {
                    Touch touch = Input.GetTouch(i);
                    this.touchPosition = touch.position;
                    this.touchPhase = touch.phase;
                    this.touchFlg = true;
                    
                    Debug.Log("タップ" + i + ":" + touch.position);
                }
                */
                
                //押した瞬間
                if(Input.GetMouseButtonDown(0)) {
                    this.touchFlg = true;
                    this.touchPhase = TouchPhase.Began;
                    Debug.Log("押した瞬間");
                }

                // 離した瞬間
                if (Input.GetMouseButtonUp(0)) {
                    this.touchFlg = true;
                    this.touchPhase = TouchPhase.Ended;
                    Debug.Log("離した瞬間");
                }
                
                // 押しっぱなし
                /*
                if (Input.GetMouseButton(0)) {
                    this.touchFlg = true;
                    this.touchPhase = TouchPhase.Moved;
                    Debug.Log("押しっぱなし");
                }
                */

                //座標取得
                if(this.touchFlg) {
                    this.touchPosition = Input.mousePosition;
                }
            }
            else { //端末
                if (Input.touchCount > 0) {

                    /*
                    Touch touch = Input.GetTouch(0);
                    this.touchPosition = touch.position;
                    this.touchPhase = touch.phase;
                    this.touchFlg = true;
                    */

                    for(int i = 0; i <= Input.touchCount-1; i++) {
                        Touch touch = Input.GetTouch(i);
                        this.touchPosition = touch.position;
                        this.touchPhase = touch.phase;
                        this.touchFlg = true;
                        
                        Debug.Log("タップ" + i + ":" + touch.position);
                    }
                }
            }
        }

        /*************
        タッチ状態取得 public TouchManagerというのは、TouchManagerクラスの中に書いているから？もしくは、ReturnでtouchManagerを返すから。
        ★newの中にある(this.touchFlg, this.touchPosition, this.touchPhase)は何？
        **************/
        public TouchManager getTouch() {
            return new TouchManager(this.touchFlg, this.touchPosition, this.touchPhase);
        }
    }
//}


