using System;
using UnityEngine;

namespace Mission.Rewards
{
    public class UnlockAreaRewardSO : RewardDataSO
    {
        [Tooltip("ID của chapter hoặc cổng cần mở khóa")]
        public string areaID;

        public override void Process()
        {
            Debug.Log($"[Reward] Unlocking area: {areaID}");
            GameFlags.SetFlag($"unlock_area_{areaID}");
        }
    }
}