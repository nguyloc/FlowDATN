using UnityEngine;

namespace Mission.Rewards
{
    [CreateAssetMenu(menuName = "FlowGame/Rewards/GiveItem")]
    public class GiveItemSO : RewardDataSO
    {
        [Tooltip("ID của Item sẽ được trao thưởng. Ví dụ: manhkyuc1, manhkyuc2, ...")]
        public string itemID; 
        public int quantity = 1;
        
        public override void Process()
        {
            Debug.Log($"[GiveItemSO] Processing reward: {itemID} x{quantity}");
            // Gọi hàm để thêm item vào kho của người chơi
            // Giả sử: // InventoryManager.Instance.AddItem(itemID, quantity);
        }
    }
}