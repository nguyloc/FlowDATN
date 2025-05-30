using System;
using FlowGame.Managers;
using FlowGame.States;
using UnityEngine;

namespace FlowGame
{
    public class TriggerZone : MonoBehaviour
    {
        public string puzzleID;
        private bool _hasTriggered;

        private void OnTriggerEnter(Collider other)
        {
            if (_hasTriggered) return;
            if (other.tag == "Player")
            {
                _hasTriggered = true;

                var flow = FindObjectOfType<GameFlowManager>();
                var puzzleManager = FindObjectOfType<PuzzleManager>();
                
                flow.ChangeState(new PuzzleState(puzzleID, puzzleManager, flow, () =>
                {
                    flow.ChangeState(new ExplorationState(flow));
                }));
            }
        }
    }
}