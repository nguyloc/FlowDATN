# 🎮 FlowGame - Script Directory Overview

Tài liệu này mô tả mục đích và chức năng của các file script của Lộc trong dự án hiện tại, nhằm dễ quản lý và bảo trì về sau.

---

## 📁 ChapterStory

- `Chapter1.cs`: Script logic riêng cho Chapter 1. Chịu trách nhiệm kiểm soát nhịp gameplay của chapter (cutscene, mission, puzzle...).
    - Được gọi từ `GameFlowManager`.
    - Chuyển trạng thái tương ứng tùy vào tiến trình.

---

## 📁 Managers

> Các script quản lý riêng biệt các hệ thống chính trong game.

- `GameFlowManager.cs`: Trung tâm điều phối trạng thái (`State Machine`). Là nơi gọi `ChangeState()` để chuyển qua lại giữa Cutscene, Dialogue, Exploration, Puzzle...
- `CutsceneManager.cs`: Quản lý logic cutscene như timeline, hoạt cảnh camera hoặc animation.
- `DialogueManager.cs`: Quản lý hệ thống hội thoại, hiển thị text theo kiểu typewriter, kèm avatar, lựa chọn rẽ nhánh.
- `PuzzleManager.cs`: Điều phối puzzle đang diễn ra, gọi khi `PuzzleState` được kích hoạt.

---

## 📁 Mission

> Quản lý hệ thống nhiệm vụ tuyến tính kèm phần thưởng.

- `Mission.cs`: Cấu trúc dữ liệu cho một nhiệm vụ. Gồm ID, tên, mô tả, trạng thái, phần thưởng, v.v.
- `MissionManager.cs`: Quản lý toàn bộ danh sách mission. Gọi `StartMission()`, `CompleteMission()` hoặc kiểm tra trạng thái hiện tại.
- `MissionStatus.cs`: Enum định nghĩa trạng thái mission (`Inactive`, `Active`, `Completed`...).

---

## 📁 States

> Các `IGameState` cụ thể, điều phối luồng gameplay chính.

- `IGameState.cs`: Interface chung cho tất cả state.
- `CutsceneState.cs`: Kích hoạt CutsceneManager, tự động chuyển sau khi xong.
- `DialogueState.cs`: Hiển thị hội thoại khi cần, chờ người chơi kết thúc.
- `ExplorationState.cs`: Cho phép người chơi di chuyển, tìm điểm trigger, nói chuyện với Fa.
- `PuzzleState.cs`: Vào chế độ giải đố, liên kết PuzzleManager.

---

## 📁 Trigger

> Các vùng đánh dấu trong thế giới game để thay đổi trạng thái hoặc kích hoạt hành động.

- `TriggerType.cs`: Enum phân loại trigger (`Dialogue`, `Puzzle`, `NPC`, `Cutscene`, etc).
- `TriggerZone.cs`: Gắn vào các vùng collider. Khi người chơi bước vào, sẽ kiểm tra loại trigger và thực thi hành động tương ứng (ví dụ: chuyển state, kích hoạt hội thoại...).

---

## 📁 Player

- `PlayerController.cs`: Quản lý input người chơi. Có thể bật/tắt điều khiển từ các state (điển hình là ExplorationState).

---

## 📁 UI

> (Tạm thời để trống - dự kiến sẽ thêm các script hiển thị mission, popup, hội thoại... trong tương lai.)

---

## 📁 Prefabs

> (Tạm thời để trống - có thể chứa các đối tượng mẫu như Trigger prefab, NPC, Puzzle Object...)

---

## 🔁 Kết nối tổng quát

---

## ✅ Gợi ý bảo trì:

- Khi thêm script mới, hãy cập nhật file này.
- Có thể chia nhỏ Managers nếu chúng ngày càng phức tạp (ví dụ: thêm `NPCManager`, `UIManager`, ...).

---

📄 **Ngày cập nhật:** 2025-05-31  
✍️ **Người cập nhật:**  Lộc



