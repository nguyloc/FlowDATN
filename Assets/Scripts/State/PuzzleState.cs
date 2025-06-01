using System;
using Player;
using UnityEngine;

namespace State
{
    public class PuzzleState : IGameState
    {
        private string _puzzleId;
        private PuzzleManager _puzzleManager;
        private PlayerController _playerController;
        private Action _onPuzzleComplete;
        
        public PuzzleState(
            string puzzleId, 
            PuzzleManager puzzleManager, 
            PlayerController playerController, 
            Action onComplete = null)
        {
            _puzzleId = puzzleId;
            _puzzleManager = puzzleManager;
            _playerController = playerController;
            _onPuzzleComplete = onComplete;
        }
        
        public void Enter()
        {
            Debug.Log($"[PuzzleState] Enter: {_puzzleId}");
            _playerController.DisableControl();
            _puzzleManager.StartPuzzle(_puzzleId, OnPuzzleFinished);
        }

        public void Exit()
        {
            Debug.Log($"[PuzzleState] Exit: {_puzzleId}");
            _playerController.EnableControl();
        }

        public void Update()
        {
            // Code to update the puzzle state each frame
        }
        
        private void OnPuzzleFinished()
        {
            Debug.Log($"[PuzzleState] Puzzle finished: {_puzzleId}");
            
            // Flags
            GameFlags.SetFlag($"puzzle_{_puzzleId}_done");
            
            // callback
            _onPuzzleComplete?.Invoke();
        }
    }
}