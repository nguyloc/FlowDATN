using FlowGame.Managers;
using UnityEngine;

namespace FlowGame.States
{
    public class PuzzleState : IGameState
    {
        private readonly GameFlowManager _gameFlowManager;
        private readonly PuzzleManager _puzzleManager;
        private readonly string _puzzleID;
        private readonly System.Action _onComplete;
        
        
        public PuzzleState(string puzzleID, PuzzleManager puzzleManager, GameFlowManager gameFlowManager, System.Action onComplete)
        {
            _puzzleID = puzzleID;
            _puzzleManager = puzzleManager;
            _gameFlowManager = gameFlowManager;
            _onComplete = onComplete;
        }
        
        public void Enter()
        {
            // Initialize the puzzle state, e.g., load the puzzle data
            // This is where you would set up the puzzle using _puzzleID and _puzzleManager
            
            Debug.Log("Entered Puzzle State" + _puzzleID);
            _puzzleManager.StartPuzzle(_puzzleID, OnCompletePuzzle);
        }

        public void Exit()
        {
            // Clean up the puzzle state, e.g., save progress or reset the puzzle
            Debug.Log("Exited Puzzle State" + _puzzleID);
        }

        public void Update()
        {
        }
        
        private void OnCompletePuzzle()
        {
            // Call the onComplete action to notify that the puzzle is completed
            _onComplete?.Invoke();
            // Optionally, you can change the state back to the previous state or another state
            //_gameFlowManager.ChangeState(new SomeOtherState()); // Replace with actual state
        }
    }
}