using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlowGame.Managers
{
    public enum CutsceneID { Intro, EndChapter }
    
    public class CutsceneManager : MonoBehaviour
    {
        [Serializable]
        public class CutsceneEntry
        {
            public CutsceneID cutsceneID;
            public GameObject cutscenePrefab;
        }

        public List<CutsceneEntry> cutscenes;
        private Dictionary<CutsceneID, GameObject> _dict;
        
        private void Awake()
        {
            _dict = new Dictionary<CutsceneID, GameObject>();
            foreach (var entry in cutscenes)
            {
                _dict[entry.cutsceneID] = entry.cutscenePrefab;
            }
        }

        public void Play(CutsceneID cutsceneID, Action onCompele)
        {
            Debug.Log("Playing cút cin: " + cutsceneID);
            StartCoroutine(Wait(2f, onCompele));
        }
        
        private IEnumerator Wait(float time, Action callback)
        {
            yield return new WaitForSeconds(time);
            callback?.Invoke();
        }
    }
}