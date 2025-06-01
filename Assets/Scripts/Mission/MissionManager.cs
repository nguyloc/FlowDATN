using System;
using System.Collections.Generic;
using Mission.Runtime;
using UnityEngine;

namespace Mission
{
    public class MissionManager : MonoBehaviour
    {
        [Header("Mission Data List (gán trong Inspector)")]
        public List<MissionDataSO> missionDataList;

        private Dictionary<string, MissionRuntime> _missionDict = new Dictionary<string, MissionRuntime>();

        private void Awake()
        {
            // Tạo runtime cho mỗi missionData
            foreach (var mData in missionDataList)
            {
                if (mData == null) continue;

                if (_missionDict.ContainsKey(mData.missionID))
                {
                    Debug.LogWarning($"[MissionManager] Duplicate missionID: {mData.missionID}, bỏ qua.");
                    continue;
                }

                var runtime = new MissionRuntime(mData);
                _missionDict.Add(mData.missionID, runtime);
            }
        }

        private void Update()
        {
            // Duyệt qua từng missionRuntime, nếu chưa completed, gọi TryComplete()
            foreach (var kvp in _missionDict)
            {
                var mission = kvp.Value;
                if (mission.status != MissionRuntime.MissionStatus.Completed)
                {
                    mission.TryComplete();
                }
            }
        }


        // Lấy runtime instance theo missionID. Trả về null nếu không tìm thấy.
        public MissionRuntime GetMissionRuntime(string missionID)
        {
            _missionDict.TryGetValue(missionID, out var runtime);
            return runtime;
        }
        
        // Gán callback khi mission hoàn thành. Có thể gọi nhiều lần; callbacks sẽ nối vào nhau.
        public void RegisterOnComplete(string missionID, Action callback)
        {
            var runtime = GetMissionRuntime(missionID);
            if (runtime != null)
            {
                runtime.onCompleteCallback += callback;
            }
            else
            {
                Debug.LogWarning($"[MissionManager] Không tìm thấy missionID = {missionID}");
            }
        }
        
        /// Lấy trạng thái hiện tại (NotStarted/InProgress/Completed) của mission.
        public MissionRuntime.MissionStatus GetMissionStatus(string missionID)
        {
            var runtime = GetMissionRuntime(missionID);
            if (runtime != null)
                return runtime.status;
            return MissionRuntime.MissionStatus.NotStarted;
        }
    }
}
