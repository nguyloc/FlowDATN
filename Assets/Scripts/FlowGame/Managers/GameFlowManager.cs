using FlowGame.ChapterStory;
using UnityEngine;

namespace FlowGame.Managers
{
    public class GameFlowManager : MonoBehaviour
    {
        private IGameState _currentState;

        public void ChangeState(IGameState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }
        
        private void Start()
        {
            // Initialize the game state, e.g., starting with the main menu
            // ChangeState(new MainMenuState());
            Chapter1 chapter1 = new Chapter1(this);
            chapter1.StartChapter();
        }
    }
}