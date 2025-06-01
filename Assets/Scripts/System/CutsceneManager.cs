using System.Collections;
using UnityEngine;

namespace System
{
    public class CutsceneManager : MonoBehaviour
    {
        // Giả lập một hệ thống quản lý cutscene => Khi nào có cutscene thật thì thay thế
        
        public void PlayCutscene(string cutsceneID, Action onComplete)
        {
            Debug.Log($"[CutsceneManager] PlayCutscene: {cutsceneID}");
            StartCoroutine(MockCutsceneRoutine(cutsceneID, onComplete));
        }

        private IEnumerator MockCutsceneRoutine(string id, Action onComplete)
        {
            // Tạm giả lập cutscene length = 2s
            yield return new WaitForSeconds(2f);
            Debug.Log($"[CutsceneManager] MockCutscene Completed: {id}");
            onComplete?.Invoke();
        }
    }
}