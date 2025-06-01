using System;
using UnityEngine;

namespace Mission.Conditions
{
    [CreateAssetMenu(menuName = "FlowGame/Conditions/TalkToNpcCondition")]
    public class TalkToNpcConditionSO : ConditionSO
    {
        [Tooltip("ID của NPC cần nói chuyện. Ví dụ: Fa, Lộc, Tú, Việt, Phong, Phúc, thêm số để phân biệt nếu cần.")]
        public string npcID;
        
        public override bool IsMet()
        {
            // Kiểm tra xem người chơi đã nói chuyện với NPC này chưa
            return GameFlags.HasFlag($"talked_{npcID}");
        }
    }
}