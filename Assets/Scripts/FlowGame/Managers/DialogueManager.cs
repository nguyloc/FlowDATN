using System;
using System.Collections;
using UnityEngine;

namespace FlowGame.Managers
{
    public class DialogueManager : MonoBehaviour
    {
        public void Show(string key, Action onComplete)
        {
            // Here you would typically fetch the dialogue text using the key
            // and display it in a UI panel. For now, we'll just log it.
            Debug.Log($"Showing dialogue for key: {key}");
            StartCoroutine(Wait(2f, onComplete));
        }

        private IEnumerator Wait(float time, Action callback)
        {
            yield return new WaitForSeconds(time);
            callback?.Invoke();
        }
    }
}