using UnityEngine;

namespace Mission.Rewards
{
    public abstract class RewardDataSO : ScriptableObject
    {
        [TextArea] public string description; // Mô tả về phần thưởng => Tương lai có thể dùng để hiển thị UI
        
        // Khi mission hoàn thành, sẽ gọi hàm này để xử lý phần thưởng
        public abstract void Process();
    }
}