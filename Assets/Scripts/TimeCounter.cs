using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TimeCounter : MonoBehaviour
{
    //カウントダウン
    public float countdown = 30.00f;
    
    //時間を表示するText型の変数
    public TextMeshProUGUI timeText;
 
    // Update is called once per frame
    void Update()
    {
        //時間をカウントダウンする

        countdown -= Time.deltaTime;
        
        //時間を表示する
        timeText.text = countdown.ToString("f2") ;
 
        //countdownが0以下になったとき
        if (countdown <= 0 )
        {
            timeText.text = "終了です";
        }
    }
}

   