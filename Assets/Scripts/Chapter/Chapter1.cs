// Thư mục: Assets/Scripts/GameFlow/Chapter/Chapter1.cs

using Dialogue;
using UnityEngine;

namespace Chapter
{

    public class Chapter1 : ChapterBase
    {
        [Header("Mission IDs cho Chapter1")]
        public string missionID_ReachPuzzle = "ReachPuzzle_Chapter1";
        public string missionID_PostPuzzleDialogue = "PostPuzzleDialogue_Chapter1";

        [Header("Dialogue Data cho Chapter1")]
        public DialogueDataSO dialogueData_PostPuzzle; // asset dialogue sau puzzle

        private void Start()
        {
            StartChapter();
        }

        public override void StartChapter()
        {
            // Register callback để khi mission “ReachPuzzle_Chapter1” complete, sẽ gọi OnReachPuzzleMissionComplete
            missionManager.RegisterOnComplete(missionID_ReachPuzzle, OnReachPuzzleMissionComplete);

            // Register callback cho mission sau khi dialogue xong
            missionManager.RegisterOnComplete(missionID_PostPuzzleDialogue, OnPostPuzzleDialogueMissionComplete);

            // Bắt đầu bằng exploration
            EnterExplorationState();
        }


        // Khi player chạm trigger zone (PuzzleTriggerZone), TriggerZone sẽ call method này
        public void OnReachedPuzzle()
        {
            Debug.Log("[Chapter1] OnReachedPuzzle()");
            // Chuyển sang PuzzleState; khi xong, call OnPuzzleSolved()
            EnterPuzzleState("RiverStone", OnPuzzleSolved);
        }


        // Callback khi PuzzleState hoàn thành (OnPuzzleFinished)
        private void OnPuzzleSolved()
        {
            Debug.Log("[Chapter1] OnPuzzleSolved()");
            // Đã set GameFlags "puzzle_RiverStone_solved" trong PuzzleState.OnPuzzleFinished()

            // Bắt đầu cutscene sau puzzle
            EnterCutsceneState("Cutscene_Chapter1_AfterPuzzle", OnCutsceneComplete);
        }

        private void OnCutsceneComplete()
        {
            Debug.Log("[Chapter1] OnCutsceneComplete()");
            // Chuyển sang DialogueState với asset dialogueData_PostPuzzle và callback OnDialoguePostPuzzleComplete
            EnterDialogueState(dialogueData_PostPuzzle, OnDialoguePostPuzzleComplete);
        }

        private void OnDialoguePostPuzzleComplete()
        {
            Debug.Log("[Chapter1] OnDialoguePostPuzzleComplete()");
            // Sau khi dialogue xong, có thể set thêm flag hoặc trực tiếp quay về exploration
            EnterExplorationState();
        }


        // Callback khi mission “ReachPuzzle_Chapter1” auto complete (MissionManager gọi).
        private void OnReachPuzzleMissionComplete()
        {
            Debug.Log("[Chapter1] Mission ReachPuzzle_Chapter1 completed!");
            // có thể unlock UI, bật next trigger, v.v.
        }


        // Callback khi mission “PostPuzzleDialogue_Chapter1” auto complete.
        private void OnPostPuzzleDialogueMissionComplete()
        {
            Debug.Log("[Chapter1] Mission PostPuzzleDialogue_Chapter1 completed!");
            // Thường là mission liên quan đến dialogue, reward, unlock area kế tiếp...
        }
    }
}
