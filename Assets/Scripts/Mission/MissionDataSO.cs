using System.Collections.Generic;
using Mission.Conditions;
using Mission.Rewards;
using UnityEngine;

namespace Mission
{
    [CreateAssetMenu(menuName = "FlowGame/MissionData")]
    public class MissionDataSO : ScriptableObject
    {
        [Header("Mission Info")]
        public string missionID;             // ID duy nhất
        public string missionTitle;          // Tên hiển thị
        [TextArea] public string description;// Mô tả

        [Header("Conditions")]
        public List<ConditionSO> conditions; // List điều kiện (các ConditionSO)

        [Header("Rewards")]
        public List<RewardDataSO> rewards;   // List reward (như GiveItem, UnlockArea)

        [Header("Prerequisite Missions (IDs)")]
        [Tooltip("Những mission khác phải hoàn thành trước khi mission này active")]
        public List<string> prerequisiteMissionIDs;
    }
}