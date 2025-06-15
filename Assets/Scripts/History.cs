using UnityEngine;
using TMPro;
using System.Collections;

public class History : MonoBehaviour
{
    [SerializeField] private GameObject historyPanel;
    [SerializeField] private TMP_Text historyText;
    [SerializeField] private GameObject acceptButton;
    [SerializeField] private AudioClip typeSound;
    private AudioSource audioSource;
    private float lastSoundTime;
    [SerializeField, TextArea(4, 6)] private string[] historyLines;


    private float typingTime = 0.03f;
    private bool didHistoryStart;
    private int lineIndex;
    private bool isTyping;

    void OnEnable()
    {
        StartHistory();
        audioSource = GetComponent<AudioSource>();
        audioSource.ignoreListenerPause = true;
    }

    void Update()
    {
        if (!didHistoryStart) return;

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                historyText.text = historyLines[lineIndex];
                isTyping = false;
            }
            else
            {
                NextHistoryLine();
            }
        }
    }
    private void StartHistory()
    {
        didHistoryStart = true;
        historyPanel.SetActive(true);
        lineIndex = 0;
        Time.timeScale = 0f;
        acceptButton.SetActive(false);
        StartCoroutine(ShowLine());
    }

    private void NextHistoryLine()
    {
        lineIndex++;
        if (lineIndex < historyLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {

            isTyping = false;
            acceptButton.SetActive(true);
  
        }
    }

    private IEnumerator ShowLine()
    {
        int charCounter = 0;
        isTyping = true;
        historyText.text = string.Empty;
        lastSoundTime = 0f;


        foreach (char ch in historyLines[lineIndex])
        {
            historyText.text += ch;
            charCounter++;

            if (typeSound != null && Time.unscaledTime - lastSoundTime > 0.16f)
            {
                audioSource.PlayOneShot(typeSound);
                lastSoundTime = Time.unscaledTime;
            }

            yield return new WaitForSecondsRealtime(typingTime);
        }
        isTyping = false;

    }

    public void CloseHistory()
    {
        didHistoryStart = false;
        historyPanel.SetActive(false);
        Time.timeScale = 1f;
    }


}
