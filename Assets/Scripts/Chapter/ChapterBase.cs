using System;
using Dialogue;
using Mission;
using Player;
using State;
using UnityEngine;

namespace Chapter
{
    public abstract class ChapterBase : MonoBehaviour
    {
        [Header("Managers Reference")]
        public GameFlowManager gameFlowManager;
        public DialogueManager dialogueManager;
        public CutsceneManager cutsceneManager;
        public PuzzleManager puzzleManager;
        public MissionManager missionManager;
        public PlayerController playerController;


        public abstract void StartChapter();
        

        protected void EnterExplorationState()
        {
            gameFlowManager.ChangeState(new ExplorationState(playerController));
        }

        protected void EnterDialogueState(DialogueDataSO dialogueData, Action onComplete = null)
        {
            gameFlowManager.ChangeState(new DialogueState(dialogueData, dialogueManager, playerController, onComplete));
        }

        protected void EnterCutsceneState(string cutsceneID, Action onComplete = null)
        {
            gameFlowManager.ChangeState(new CutsceneState(cutsceneID, cutsceneManager, playerController, onComplete));
        }

        protected void EnterPuzzleState(string puzzleID, Action onComplete = null)
        {
            gameFlowManager.ChangeState(new PuzzleState(puzzleID, puzzleManager, playerController, onComplete));
        }
    }
}