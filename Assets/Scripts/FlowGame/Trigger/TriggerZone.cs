using FlowGame.ChapterStory;
using UnityEngine;

namespace FlowGame.Trigger
{
    public class TriggerZone : MonoBehaviour
    {
        public TriggerType triggerType;
        public Chapter1 chapter1;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;

            switch (triggerType)
            {
                case TriggerType.Fa:
                    chapter1.OnReachedFa();
                    break;
                case TriggerType.Puzzle:
                    chapter1.OnReachedPuzzle();
                    break;
            }
            
            // Disable the trigger after it has been activated
            GetComponent<Collider>().enabled = false;
        }
    }
}