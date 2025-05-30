using FlowGame.Managers;

namespace FlowGame.States
{
    public class DialogueState : IGameState
    {
        private string _key;
        private DialogueManager _dialogueManager;
        private GameFlowManager _gameFlowManager;
        private System.Action _onComplete;
        
        public DialogueState(string key, DialogueManager dialogueManager, GameFlowManager gameFlowManager, System.Action onComplete)
        {
            _key = key;
            _dialogueManager = dialogueManager;
            _gameFlowManager = gameFlowManager;
            _onComplete = onComplete;
        }
        
        public void Enter()
        {
            _dialogueManager.Show(_key, _onComplete);
        }

        public void Exit()
        {
        }
    }
}