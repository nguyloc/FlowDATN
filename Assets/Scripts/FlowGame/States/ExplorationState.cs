using FlowGame.Managers;
using Player;

namespace FlowGame.States
{
    public class ExplorationState : IGameState
    {
        private readonly GameFlowManager _gameFlowManager;
        
        public ExplorationState(GameFlowManager gameFlowManager)
        {
            _gameFlowManager = gameFlowManager;
        }
        
        
        public void Enter()
        {
            // Initialize exploration state, e.g., setting up the environment, player controls, etc.
            // This could involve loading a scene, enabling player movement, etc.
            // For now, we will just log that we have entered the exploration state.
            UnityEngine.Debug.Log("Entered Exploration State");
            PlayerController.Instance.EnableControls();
        }

        public void Exit()
        {
            // Clean up when exiting the exploration state, e.g., disabling player controls, saving state, etc.
            UnityEngine.Debug.Log("Exited Exploration State");
            PlayerController.Instance.DisableControls();
           
        }

        public void Update()
        {
        }
    }
}