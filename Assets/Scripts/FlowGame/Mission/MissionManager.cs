using System.Collections.Generic;
using UnityEngine;

namespace FlowGame.Mission
{
    public class MissionManager : MonoBehaviour
    {
        public List<Mission> missions;
        
        private Dictionary<string, Mission> _missionDict;
        
        private void Awake()
        {
            _missionDict = new Dictionary<string, Mission>();
            foreach (var mission in missions)
            {
                _missionDict[mission.missionID] = mission;
            }
        }

        public void StartMission(string id)
        {
            if (_missionDict.TryGetValue(id, out var mission))
            {
                mission.StartMission();
            }
            else
            {
                Debug.LogWarning($"Mission ID {id} not found");
            }
        }

        public void CompleteMission(string id)
        {
            if (_missionDict.TryGetValue(id, out var mission))
            {
                mission.CompleteMission();
                HandleReward(mission.rewardID);
            }
        }

        public MissionStatus GetStatus(string id)
        {
            return _missionDict.TryGetValue(id, out var mission) ? mission.status : MissionStatus.NotStarted;
        }

        private void HandleReward(string rewardID)
        {
            if (!string.IsNullOrEmpty(rewardID))
            {
                Debug.Log($"[REWARD] Player received: {rewardID}");
                //TODO: Gắn vào InventoryManager, PlayerStats, v.v.
            }
        }
    }
}
