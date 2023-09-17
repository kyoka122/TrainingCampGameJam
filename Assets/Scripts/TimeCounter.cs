using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TimeCounter : MonoBehaviour
{
    public float countTime { get; private set; }
    
    //時間を表示するText型の変数
    public TextMeshProUGUI timeText;
 
    public void Init(float timeValue)
    {
        countTime = timeValue;
        timeText.text = timeValue.ToString("f2");
    }
    public void UpdateTimer()
    {
        //countdownが0以下になったとき
        if (countTime <= 0 )
        {
            return;
        }
        
        //時間をカウントダウンする

        countTime -= Time.deltaTime;
        
        //時間を表示する
        timeText.text = countTime.ToString("f2") ;

    }
    
    public bool IsTimeOver()
    {
        return countTime <= 0;
    }
}

   