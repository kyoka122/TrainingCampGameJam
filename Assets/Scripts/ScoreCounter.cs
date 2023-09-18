using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public float score = 0.0f; // スコアを0に初期化
    public float scoreIncrementRate = 100.0f; // 1秒あたりのスコア増加率
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        UpdateScoreText();
    }

    private void Update()
    {
        // 1秒ごとにスコアを増加
        if(score<=100){
        score += scoreIncrementRate * Time.deltaTime;
        UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString("F2")+"m"; // スコアを整数値として表示
    }
}