using System.Collections.Generic;
using MyApplication;
using Character;
using DefaultNamespace;
using InGameManagerStates;
using UI;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public abstract class BaseInGameState : MonoBehaviour
    {
        protected abstract InGameState State { get; }
        [SerializeField] private InGameData inGameData;


        protected List<InGameStateData> StateData=>inGameData.stateData;
        protected JumpCharacterHeightModel Character=>inGameData.character;
        protected BorderLine BorderLine=>inGameData.borderLine;
        protected GameObject BorderLineView=>inGameData.borderLineView;
        protected float BorderLineUnderLength=>inGameData.borderLineDisplayLength;
        protected float BorderLineDisplayLength=>inGameData.borderLineDisplayLength;
        protected float JumpPower=>inGameData.jumpPower;
        protected TimeCounter Timer=>inGameData.timer;
        private InGameUI InGameUI=>inGameData.inGameUI;
        protected Spawner Spawner=>inGameData.spawner;
        protected GetClick GetClick=>inGameData.getClick;
        protected SpriteRenderer JumpObjectBase=>inGameData.jumpObjectBase;

        protected CardData CardData => inGameData.cardData;
        
        protected float GameTime=>inGameData.gameTime;
        
        private BaseInGameState _currentInGameState;

        /// <summary>
        /// 最初に指定したコンポーネントのみで呼ばれる
        /// </summary>
        public async void Run()
        {
            Timer.Init(GameTime);
            InGameUI.Init();
            Spawner.Init();
            
            
            _currentInGameState = GetComponent<BaseInGameState>();

            await InGameUI.CountDownAsync();

            Character.Jump(JumpPower);
            _currentInGameState.Entry();
            
            this.UpdateAsObservable()
                .Subscribe(_ =>
                {
                    var newState = _currentInGameState.UpdateGame();
                    if (newState!=_currentInGameState.State)
                    {
                        _currentInGameState.Exit();
                        _currentInGameState = StateData.Find(data => data.State==newState).InGameState;
                        Debug.Log($"newState:{newState}");
                        _currentInGameState.Entry();
                    }

                }).AddTo(this);
        }
        

        protected abstract void Entry();

        protected abstract InGameState UpdateGame();

        protected abstract void Exit();
        

        #region Actions
        
        protected bool OverBorderline()
        {
            return Character.HeightObservable.Value < BorderLine.HeightObservable.Value;
        }

        protected async void GameOver()
        {
            await InGameUI.GameOverAsync();
            ScoreHolder.score = Character.HeightObservable.Value;
            SceneManager.LoadScene(SceneName.Score);
        }

        protected async void Finish()
        {
            await InGameUI.PopUpFinishAsync();
            ScoreHolder.score = Character.HeightObservable.Value;
            SceneManager.LoadScene(SceneName.Score);
        }

        #endregion

    }
}