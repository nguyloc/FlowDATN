using System;
using Dialogue;
using Player;
using UnityEngine;

namespace State
{
    public class DialogueState : IGameState
    {
        private DialogueDataSO _dialogueData;
        private DialogueManager _dialogueManager;
        private PlayerController _playerController;
        private Action _onDialogueComplete;
        
        public DialogueState(
            DialogueDataSO dialogueData, 
            DialogueManager dialogueManager, 
            PlayerController playerController, 
            Action onDialogueComplete)
        {
            _dialogueData = dialogueData;
            _dialogueManager = dialogueManager;
            _playerController = playerController;
            _onDialogueComplete = onDialogueComplete;
        }
        
        public void Enter()
        {
            Debug.Log($"[DialogueState] Entering dialogue state: {_dialogueData.ID}");
            _playerController.DisableControl();
            _dialogueManager.ShowDialogueSequence(_dialogueData, OnDialogueFinished);
        }

        public void Exit()
        {
            Debug.Log($"[DialogueState] Exiting dialogue state: {_dialogueData.ID}");
            _playerController.EnableControl();
        }

        public void Update()
        {
            // Code to update the dialogue state each frame
        }
        
        private void OnDialogueFinished()
        {
            Debug.Log($"[DialogueState] Dialogue finished: {_dialogueData.ID}");
            
            // Flags
            GameFlags.SetFlag($"dialogue_{_dialogueData.ID}_done");
            
            // callback
            _onDialogueComplete?.Invoke();
            
        }
    }
}