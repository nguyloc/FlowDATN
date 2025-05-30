using System.Collections;
using UnityEngine;

namespace FlowGame.Managers
{
    public class PuzzleManager : MonoBehaviour
    {
        public void StartPuzzle(string id, System.Action onComplete)
        {
            Debug.Log($"Starting puzzle {id}...");
            StartCoroutine(MockPuzzleRoutine(onComplete));
        }

        private IEnumerator MockPuzzleRoutine(System.Action onComplete)
        {
            // Mô phỏng thời gian giải đố
            yield return new WaitForSeconds(3f);
            Debug.Log("Puzzle Complete!");
            onComplete?.Invoke();
        }
    }
}