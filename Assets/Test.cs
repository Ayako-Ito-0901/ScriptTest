using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss
{
    private int hp = 100; //体力　Bossクラス内のメンバ関数
    private int power = 25; //攻撃力
    private int mp = 53; //mp

    //攻撃用関数　Bossクラス内のメンバ関数
    public void Attack() {
        Debug.Log(this.power + "のダメージを与えた");
    }

    //防御用の関数
    public void Defence(int damage) {
        Debug.Log(damage + "のダメージを受けた！");

        //残りhpを減らす
        this.hp -= damage; //「このクラスのメンバ変数を使う」ことを明示的に示している
    }

    //Magic関数 mpを消費して魔法攻撃をする
    public void Magic() {
        if(this.mp >= 5) {
            this.mp -= 5;
            Debug.Log("魔法攻撃をした。残りMPは" + this.mp);
        }
        else {
            Debug.Log("MPが足りないため、魔法が使えない。");
        }
    }

}

public class Test : MonoBehaviour
{
    int Add(int a, int b)
    {
        return a + b;
    }
    // Start is called before the first frame update 最初に一度だけ実行する処理
    void Start()
    {

        // ★課題提出用　配列を初期化する
        int[] points = {10, 20, 30, 40, 50};
        int maxCount = points.Length;
        //配列の各要素の値を順番に表示
        for(int i = 0; i <= maxCount-1; i++) {
            Debug.Log(points[i]);
        }
        //配列の各要素の値を逆順に表示
        for(int i = maxCount-1; i >= 0; i--) {
            Debug.Log(points[i]);
        }


        //Bossクラスの変数宣言＆インスタンス化
        Boss lastboss = new Boss();
        //攻撃用の関数を呼び出す
        lastboss.Attack();

        //防御用の関数を呼び出す；
        lastboss.Defence(3);

        //魔法攻撃を10回呼び出す
        for(int i=1; i <= 10; i++) {
            Debug.Log(i + "回目の攻撃");
            lastboss.Magic();
        }

        lastboss.Magic();
    }

    // Update is called once per frame 毎フレーム実行する処理
    void Update()
    {

    }
}
