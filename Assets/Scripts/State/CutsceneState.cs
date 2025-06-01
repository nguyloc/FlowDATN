using System;
using Player;
using UnityEngine;

namespace State
{
    public class CutsceneState : IGameState
    {
        private string _cutsceneID;
        private CutsceneManager _cutsceneManager;
        private PlayerController _playerController;
        private Action _onCutsceneComplete;
        
        public CutsceneState(
            string cutsceneID, 
            CutsceneManager cutsceneManager, 
            PlayerController playerController, 
            Action onCutsceneComplete)
        {
            _cutsceneID = cutsceneID;
            _cutsceneManager = cutsceneManager;
            _playerController = playerController;
            _onCutsceneComplete = onCutsceneComplete;
        }
        
        public void Enter()
        {
            Debug.Log($"[CutsceneState] Entering cutscene state: {_cutsceneID}");
            _playerController.DisableControl();
            _cutsceneManager.PlayCutscene(_cutsceneID, OnCutsceneFinished);
        }

        public void Exit()
        {
            Debug.Log($"[CutsceneState] Exiting cutscene state: {_cutsceneID}");
            _playerController.EnableControl();
        }

        public void Update()
        {
            // Code to update the cutscene state each frame
        }
        
        private void OnCutsceneFinished()
        {
            Debug.Log($"[CutsceneState] Cutscene finished: {_cutsceneID}");
            
            // Flags
            GameFlags.SetFlag($"cutscene_{_cutsceneID}_done");
            
            // callback
            _onCutsceneComplete?.Invoke();
        }
    }
}