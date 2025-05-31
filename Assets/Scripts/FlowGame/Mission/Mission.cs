using System;

namespace FlowGame.Mission
{
    [Serializable]
    public class Mission
    {
        public string missionID;
        public string description;
        public MissionStatus status = MissionStatus.NotStarted;
        public string rewardID;
        
        public Action onMissionCompleted;
        
        public void StartMission()
        {
            if (status == MissionStatus.NotStarted)
            {
                status = MissionStatus.InProgress;
                // Logic to start the mission
                Console.WriteLine($"Mission {missionID} started: {description}");
            }
        }
        
        public void CompleteMission()
        {
            if (status == MissionStatus.InProgress)
            {
                status = MissionStatus.Completed;
                // Logic to complete the mission
                Console.WriteLine($"Mission {missionID} completed: {description}");
                
                onMissionCompleted?.Invoke();
            }
        }
    }
}