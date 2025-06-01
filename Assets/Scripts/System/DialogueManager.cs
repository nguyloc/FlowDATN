using System.Collections;
using Dialogue;
using TMPro;
using UnityEngine;

namespace System
{
    public class DialogueManager : MonoBehaviour
    {
        [Header("UI Elements")]
        public CanvasGroup dialogueUI;
        public TextMeshProUGUI speakerNameText;
        public TextMeshProUGUI dialogueText;
        
        [Header("Controls")]
        public KeyCode nextKey = KeyCode.Space; // => Co the doi phim de tiep tuc hoi thoai
        
        private DialogueDataSO _currentData;
        private int _currentLineIndex;
        private bool _isPlaying;
        private Action _onCompleteCallback;

        private void Awake()
        {
            // An UI khi bat dau
            dialogueUI.alpha = 0;
            dialogueUI.interactable = false;
            dialogueUI.blocksRaycasts = false;
        }

        private void Update()
        {
            if (!_isPlaying) return;
            
            if (Input.GetKeyDown(nextKey)) ShowNextLine();
        }

        public void ShowDialogueSequence(DialogueDataSO data, Action onComplete)
        {
            if (data == null || data.lines == null || data.lines.Count == 0)
            {
                Debug.LogWarning("Dialogue data is empty or null.");
                
                onComplete?.Invoke();
                return;
            }
            
            _currentData = data;
            _currentLineIndex = 0;
            _isPlaying = true;
            _onCompleteCallback = onComplete;
            
            // Hien thi UI
            dialogueUI.alpha = 1;
            dialogueUI.interactable = true;
            dialogueUI.blocksRaycasts = true;
            
            // Corotine show 
            StartCoroutine(PlayDialogueCoroutine());
        }

        private IEnumerator PlayDialogueCoroutine()
        {
            while (_currentLineIndex < _currentData.lines.Count)
            {
                var line = _currentData.lines[_currentLineIndex];

                // Hiển thị tên speaker
                speakerNameText.text = line.speakerID;

                // Lấy text đã translate từ Unity Localization
                var localizedString = new LocalizedString
                {
                    TableReference = line.tableReference,
                    TableEntryReference = line.keyLocalization
                };

                // Lấy text (đồng bộ nếu table đã load)
                var textValue = localizedString.GetLocalizedString();
                dialogueContentText.text = textValue;

                // Nếu line.displayTime > 0, chờ tự động next
                if (line.displayTime > 0f)
                {
                    yield return new WaitForSeconds(line.displayTime);
                }
                else
                {
                    // Đợi cho đến khi player bấm NextKey
                    bool waited = false;
                    while (!waited)
                    {
                        if (Input.GetKeyDown(nextKey))
                            waited = true;
                        yield return null;
                    }
                }

                _currentLineIndex++;
            }

            // Khi hết các dòng
            EndDialogueUI();
            _onCompleteCallback?.Invoke();
        }
        
        public void ShowNextLine()
        {
            _currentLineIndex++;
        }
        
        private void EndDialogueUI()
        {
            _isPlaying = false;
            dialogueUI.alpha = 0;
            dialogueUI.interactable = false;
            dialogueUI.blocksRaycasts = false;
        }
    }
}