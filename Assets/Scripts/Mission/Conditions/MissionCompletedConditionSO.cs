using System;
using UnityEngine;

namespace Mission.Conditions
{
    [CreateAssetMenu(menuName = "FlowGame/Conditions/TalkToNpcCondition")]
    public class MissionCompletedConditionSO : ConditionSO
    {
        [Tooltip("ID của mission cần kiểm tra đã hoàn thành")]
        public string missionID;
        
        public override bool IsMet()
        {
            return GameFlags.HasFlag($"mission_{missionID}_completed");
        }
    }
}