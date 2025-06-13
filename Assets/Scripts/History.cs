using UnityEngine;
using TMPro;
using System.Collections;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject historyPanel;
    [SerializeField] private TMP_Text historyText;
    [SerializeField, TextArea(4, 6)] private string[] historyLines;


    private float typingTime = 0.03f;
    private bool didHistoryStart;
    private int lineIndex;
    private bool isTyping;

    void OnEnable()
    {
        // Se ejecuta cuando el panel History se activa
        StartHistory();
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
            didHistoryStart = false;
            historyPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    private IEnumerator ShowLine()
    {
        isTyping = true;
        historyText.text = string.Empty;

        foreach (char ch in historyLines[lineIndex])
        {
            historyText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }

        isTyping = false;
    }


}
