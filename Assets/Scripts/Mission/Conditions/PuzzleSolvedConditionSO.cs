using System;
using UnityEngine;

namespace Mission.Conditions
{
    [CreateAssetMenu(menuName = "FlowGame/Conditions/TalkToNpcCondition")]
    public class PuzzleSolvedConditionSO : ConditionSO
    {
        [Tooltip("ID của puzzle. Ví dụ: puzzle_01, LauDaiTinhAi")]
        public string puzzleID;
        
        public override bool IsMet()
        {
            return GameFlags.HasFlag($"puzzle_{puzzleID}_solved");
        }
    }
}