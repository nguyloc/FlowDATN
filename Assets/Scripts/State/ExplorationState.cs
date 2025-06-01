using Player;

namespace State
{
    public class ExplorationState : IGameState
    {
        private PlayerController _playerController;
        
        public ExplorationState(PlayerController playerController)
        {
            _playerController = playerController;
        }
        
        public void Enter()
        {
            _playerController.EnableControl();
        }

        public void Exit()
        {
            _playerController.DisableControl();
        }

        public void Update()
        {
            // Code to update the exploration state each frame
        }
    }
}