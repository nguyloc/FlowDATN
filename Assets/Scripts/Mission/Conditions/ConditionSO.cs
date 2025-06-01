using UnityEngine;

namespace Mission.Conditions
{
    public abstract class ConditionSO : ScriptableObject
    {
        [TextArea] public string description;  // Mô tả điều kiện => Trong tương lai có thể dùng để hiển thị UI
        
        public abstract bool IsMet();
    }
}