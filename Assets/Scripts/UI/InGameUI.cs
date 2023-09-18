using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Utility.PanelAnimation;

namespace UI
{
    public class InGameUI:MonoBehaviour
    {
        #region CountDown
        
        [SerializeField] private TextMeshProUGUI countDownText;
        [SerializeField] private float startTextDuration;
        
        private Transform _countDownTransform ;
        private int _count = 4;

        public void Init()
        {
            _countDownTransform = countDownText.transform;
            _countDownTransform.localScale=Vector3.zero;
        }
        public async UniTask CountDownAsync()
        {
            countDownText.gameObject.SetActive(true);
            await DOTween.Sequence()
                .AppendCallback(CountTextDown)
                .Append(_countDownTransform.DOScale(Vector3.one, 0.3f))
                .AppendInterval(0.4f)
                .Append(_countDownTransform.DOScale(Vector3.zero, 0.3f))
                .SetLoops(3);
            
            countDownText.text = "スタート";
            await _countDownTransform.DOScale(Vector3.one, 0.3f);
            await UniTask.Delay(TimeSpan.FromSeconds(startTextDuration), cancellationToken:this.GetCancellationTokenOnDestroy());
            countDownText.gameObject.SetActive(false);
        }
        
        private void CountTextDown()
        {
            _count--;
            countDownText.text = _count.ToString();
        }

        #endregion

        
        #region FinishUI
        
        [SerializeField] private TextMeshProUGUI finishText;
        [SerializeField] private float popUpTime;
        [SerializeField] private float finishTextDuration;
        
        public async UniTask PopUpFinishAsync()
        {
            finishText.gameObject.SetActive(true);
            PopAnimation popAnimation= new PopAnimation(gameObject, popUpTime, 0);
            await popAnimation.Enter(this.GetCancellationTokenOnDestroy());
            await UniTask.Delay(TimeSpan.FromSeconds(finishTextDuration), cancellationToken:this.GetCancellationTokenOnDestroy());
            //finishText.gameObject.SetActive(false);
        }
        

        #endregion

        
        #region GameOverUI

        [SerializeField] private TextMeshProUGUI gameOverText;
        [SerializeField] private float gameOverFadeInDuration;
        [SerializeField] private float gameOverTextDuration;
        
        public async UniTask GameOverAsync()
        {
            gameOverText.color = new Color(gameOverText.color.r,gameOverText.color.g,gameOverText.color.b,0);
            gameOverText.gameObject.SetActive(true);
            await gameOverText.DOFade(1, gameOverFadeInDuration)
                .SetEase(Ease.OutSine);
            await UniTask.Delay(TimeSpan.FromSeconds(gameOverTextDuration), cancellationToken:this.GetCancellationTokenOnDestroy());
            //gameOverText.gameObject.SetActive(false);
        }

        #endregion
        
    }
}