using FlowGame.Managers;
using FlowGame.Mission;
using FlowGame.States;
using UnityEngine;

namespace FlowGame.ChapterStory
{
    public class Chapter1 : MonoBehaviour
    {
        public GameFlowManager gameFlowManager;
        public CutsceneManager cutsceneManager;
        public DialogueManager dialogueManager;
        public PuzzleManager puzzleManager;
        public MissionManager missionManager;

        public void StartChapter()
        {
            gameFlowManager.ChangeState(new CutsceneState(CutsceneID.Intro, cutsceneManager, gameFlowManager, OnCutsceneFinished));
        }
        
        private void OnCutsceneFinished()
        {
            missionManager.StartMission("MeetFa");
            gameFlowManager.ChangeState(new ExplorationState(gameFlowManager));
        }
        
        public void OnReachedFa()
        {
            gameFlowManager.ChangeState(new DialogueState("MeetFa", dialogueManager, gameFlowManager, OnDialogueWithFaFinished));
        }
        
        private void OnDialogueWithFaFinished()
        {
            missionManager.CompleteMission("MeetFa");
            missionManager.StartMission("ReachPuzzle");
            gameFlowManager.ChangeState(new ExplorationState(gameFlowManager));
        }
        
        public void OnReachedPuzzle()
        {
            gameFlowManager.ChangeState(new PuzzleState("SolvePuzzle", puzzleManager, gameFlowManager, OnPuzzleSolved));
        }
        
        private void OnPuzzleSolved()
        {
            missionManager.CompleteMission("ReachPuzzle");
            Debug.Log("Puzzle solved! Chapter 1 completed.");
        }
    }
}