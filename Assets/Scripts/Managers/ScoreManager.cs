using System;
using Cysharp.Threading.Tasks;
using DefaultNamespace;
using KanKikuchi.AudioManager;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Managers
{
    public class ScoreManager:MonoBehaviour
    {
        [SerializeField] private ScoreCounter scoreCounter;

        private async void Start()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(2.0f),cancellationToken:this.GetCancellationTokenOnDestroy());
            BGMManager.Instance.Play(BGMPath.IN_GAME_BGM, 0.4f);
            this.UpdateAsObservable().Subscribe(_=>
            {
                PlayCount();
            }).AddTo(this);
        }

        private void PlayCount()
        {

            scoreCounter.UpdateScore(ScoreHolder.score);
        }
    }
}