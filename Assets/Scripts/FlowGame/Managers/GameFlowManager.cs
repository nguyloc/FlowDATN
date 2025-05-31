using FlowGame.ChapterStory;
using FlowGame.Mission;
using UnityEngine;

namespace FlowGame.Managers
{
    public class GameFlowManager : MonoBehaviour
    {
        private IGameState _currentState;
        
        public CutsceneManager cutsceneManager;
        public DialogueManager dialogueManager;
        public PuzzleManager puzzleManager;
        public MissionManager missionManager;
        
        public Chapter1 _chapter1;
        
        private void Start()
        {
            // Initialize the game state, e.g., starting with the main menu
            // ChangeState(new MainMenuState());
           
            _chapter1.StartChapter();
        }

        public void ChangeState(IGameState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }
        
        private void Update()
        {
            _currentState?.Update();
        }
    }
}