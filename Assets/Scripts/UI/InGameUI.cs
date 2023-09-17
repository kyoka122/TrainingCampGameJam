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
        private int _count;

        public void Init()
        {
            _countDownTransform = countDownText.transform;
            _countDownTransform.localScale=Vector3.zero;
        }
        public async UniTask CountDownAsync()
        {
            await DOTween.Sequence()
                .AppendCallback(CountTextDown)
                .Append(_countDownTransform.DOScale(Vector3.one, 0.3f))
                .AppendInterval(0.4f)
                .Append(_countDownTransform.DOScale(Vector3.zero, 0.3f))
                .SetLoops(3);
            countDownText.text = "スタート";
            await UniTask.Delay(TimeSpan.FromSeconds(startTextDuration), cancellationToken:this.GetCancellationTokenOnDestroy());
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
        [SerializeField] private float activeTime;
        
        public async UniTask PopUpFinishAsync()
        {
            PopAnimation popAnimation= new PopAnimation(gameObject, popUpTime, 0);
            await popAnimation.Enter(this.GetCancellationTokenOnDestroy());
        }
        

        #endregion

        
        #region GameOverUI

        [SerializeField] private TextMeshProUGUI gameOverText;
        [SerializeField] private float gameOverFadeInDuration;
        
        public async UniTask GameOverAsync()
        {
            await gameOverText.DOFade(1, gameOverFadeInDuration)
                .SetEase(Ease.OutSine);
            
        }

        #endregion
        
    }
}