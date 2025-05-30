using FlowGame.Managers;
using FlowGame.States;
using UnityEngine;

namespace FlowGame.ChapterStory
{
    public class Chapter1
    {
        private readonly GameFlowManager _gameFlowManager;
        private readonly CutsceneManager _cutsceneManager;
        private readonly DialogueManager _dialogueManager;

        public Chapter1(GameFlowManager gameFlowManager)
        {
            _gameFlowManager = gameFlowManager;
            _cutsceneManager = Object.FindObjectOfType<CutsceneManager>();
            _dialogueManager = Object.FindObjectOfType<DialogueManager>();
        }

        public void StartChapter()
        {
            _gameFlowManager.ChangeState(new CutsceneState(CutsceneID.Intro, _cutsceneManager, _gameFlowManager, () =>
            {
                _gameFlowManager.ChangeState(new DialogueState("C1_Intro_01", _dialogueManager, _gameFlowManager, () =>
                {
                    Debug.Log("✅ Chapter 1 ready to explore...");
                }));
            }));
        }
    }
}