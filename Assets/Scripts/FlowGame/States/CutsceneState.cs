using System;
using FlowGame.Managers;

namespace FlowGame.States
{
    public class CutsceneState : IGameState
    {
        private CutsceneID _id;
        private GameFlowManager _gameFlowManager;
        private CutsceneManager _cutsceneManager;
        private Action _onComplete;
        
        public CutsceneState(CutsceneID id, CutsceneManager cutsceneManager ,GameFlowManager gameFlowManager, Action onComplete)
        {
            _id = id;
            _gameFlowManager = gameFlowManager;
            _cutsceneManager = cutsceneManager;
            _onComplete = onComplete;
        }
        
        public void Enter()
        {
            _cutsceneManager.Play(_id, _onComplete);
        }

        public void Exit()
        {
            // Optionally, handle any cleanup or state transition logic here
            //_cutsceneManager.Stop();
            //_onComplete?.Invoke();
            //_gameFlowManager.ChangeState(new MainMenuState()); // Example of transitioning to another state
        }

        public void Update()
        {
            // Handle any updates needed during the cutscene state
            // This could include checking for user input or other conditions
            // For now, we will leave it empty as the cutscene manager handles playback
        }
    }
}