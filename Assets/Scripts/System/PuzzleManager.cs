using System.Collections.Generic;
using UnityEngine;

namespace System
{
    public class PuzzleManager : MonoBehaviour
    {
        [Serializable]
        public struct PuzzleEntry
        {
            [Tooltip("ID dùng để gọi đến puzzle. Ví dụ: MeetFa")]
            public string puzzleID;
            
            [Tooltip("Prefab của puzzle. Chứa logic của puzzle.")]
            public GameObject puzzlePrefab;
        }
        
        [Header("Danh sách mapping puzzleID với prefab")]
        public List<PuzzleEntry> puzzleEntries = new List<PuzzleEntry>();
        
        private Dictionary<string, PuzzleEntry> _puzzleDict;

        private void Awake()
        {
            // Khởi tạo dictionary từ list
            _puzzleDict = new Dictionary<string, PuzzleEntry>();
            foreach (var entry in puzzleEntries)
            {
                if (string.IsNullOrWhiteSpace(entry.puzzleID))
                {
                    Debug.LogWarning("[PuzzleManager] puzzleID trống, bỏ qua entry.");
                    continue;
                }

                if (_puzzleDict.ContainsKey(entry.puzzleID))
                {
                    Debug.LogWarning($"[PuzzleManager] Trùng puzzleID: {entry.puzzleID}, bỏ entry sau.");
                    continue;
                }

                _puzzleDict.Add(entry.puzzleID, entry);
            }
        }
        
        public void StartPuzzle(string puzzleID, Action onComplete)
        {
            if (!_puzzleDict.TryGetValue(puzzleID, out var entry))
            {
                Debug.LogError($"[PuzzleManager] Không tìm thấy puzzleID = {puzzleID}");
                onComplete?.Invoke();
                return;
            }

            // Instantiate prefab puzzle
            var go = Instantiate(entry.puzzlePrefab);
            go.name = $"{entry.puzzlePrefab.name}_{puzzleID}";

            // Find component IPuzzle (các prefab puzzle phải implement IPuzzle)
            var puzzleComponent = go.GetComponent<IPuzzle>();
            if (puzzleComponent != null)
            {
                puzzleComponent.Initialize(onComplete);
            }
            else
            {
                Debug.LogWarning($"[PuzzleManager] Prefab {entry.puzzlePrefab.name} không có IPuzzle.");
                onComplete?.Invoke();
                Destroy(go);
            }
        }
    }
}