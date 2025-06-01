using System;
using UnityEngine;

namespace Mission.Runtime
{
    public class MissionRuntime
    {
        public enum MissionStatus { NotStarted, InProgress, Completed }

        public MissionDataSO data;
        public MissionStatus status;
        public Action onCompleteCallback;

        public MissionRuntime(MissionDataSO dataSO)
        {
            data = dataSO;
            status = MissionStatus.NotStarted;
        }

        public void TryComplete()
        {
            if (status == MissionStatus.Completed) return;

            // Kiểm tra prerequisite missions
            if (data.prerequisiteMissionIDs != null)
            {
                foreach (var preID in data.prerequisiteMissionIDs)
                {
                    if (!GameFlags.HasFlag($"mission_{preID}_completed"))
                    {
                        // Chưa đủ điều kiện để bắt đầu mission này
                        return;
                    }
                }
            }

            // Nếu mới NotStarted, đổi sang InProgress
            if (status == MissionStatus.NotStarted)
            {
                status = MissionStatus.InProgress;
                Debug.Log($"[Mission] Started: {data.missionID}");
            }

            // Kiểm tra tất cả conditions
            bool allMet = true;
            if (data.conditions != null)
            {
                foreach (var cond in data.conditions)
                {
                    if (!cond.IsMet())
                    {
                        allMet = false;
                        break;
                    }
                }
            }

            // Nếu all conditions met, Complete mission
            if (allMet)
            {
                Complete();
            }
        }

        private void Complete()
        {
            status = MissionStatus.Completed;
            Debug.Log($"[Mission] Completed: {data.missionID}");

            // Set global flag
            GameFlags.SetFlag($"mission_{data.missionID}_completed");

            // Process reward
            if (data.rewards != null)
            {
                foreach (var r in data.rewards)
                {
                    r.Process();
                }
            }

            // Gọi callback registered (nếu có)
            onCompleteCallback?.Invoke();
        }
    }
}
