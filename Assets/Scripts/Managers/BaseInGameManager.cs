using System.Collections.Generic;
using System.Linq;
using Application;
using Character;
using InGameManagerStates;
using UI;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public abstract class BaseInGameManager : MonoBehaviour
    {
        protected abstract InGameState State { get; }
        
        [SerializeField] private List<InGameStateData> stateData;
        [SerializeField] protected JumpCharacterHeightModel character;
        [SerializeField] protected BorderLine borderLine;
        [SerializeField] protected GameObject borderLineView;
        [SerializeField] protected float borderLineUnderLength;
        [SerializeField] protected float borderLineDisplayLength;
        [SerializeField] protected float jumpPower;
        [SerializeField] protected Timer timer;
        [SerializeField] private InGameUI inGameUI;
        [SerializeField] protected Spawner spawner;
        
        [SerializeField] protected float gameTime;
        [SerializeField] private int speedAndCardUpRate = 5;
        
        private BaseInGameManager _currentInGameManager;

        protected int jumpCount = 0;
        protected int cardCount = 1;
        
        private async void Start()
        {
            timer.Init(gameTime);
            inGameUI.Init();
            spawner.Init();
            _currentInGameManager = stateData.Find(data => data.State==InGameState.Jumping).InGameManager;
            _currentInGameManager.Entry();

            await inGameUI.CountDownAsync();

            this.UpdateAsObservable()
                .Subscribe(_ =>
                {
                    var newState = _currentInGameManager.UpdateGame();
                    if (newState!=_currentInGameManager.State)
                    {
                        _currentInGameManager.Exit();
                        _currentInGameManager = stateData.Find(data => data.State==newState).InGameManager;
                        _currentInGameManager.Entry();
                    }
                }).AddTo(this);
        }
        

        protected abstract void Entry();

        protected abstract InGameState UpdateGame();

        protected abstract void Exit();
        

        #region Actions
        
        protected bool OverBorderline()
        {
            return character.HeightObservable.Value < borderLine.HeightObservable.Value;
        }

        protected async void GameOver()
        {
            await inGameUI.GameOverAsync();
            SceneManager.LoadScene(SceneName.Score);
        }

        protected async void Finish()
        {
            await inGameUI.PopUpFinishAsync();
            SceneManager.LoadScene(SceneName.Score);
        }

        #endregion

    }
}