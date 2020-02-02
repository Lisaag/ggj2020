using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private bool startOnAwake = true;
    [SerializeField] private float time = 5f;
    private float currentTime = float.PositiveInfinity;

    [Header("References")]
    [SerializeField] private ScriptableManager manager;
    [SerializeField] private Text text;

    [Header("Events")]
    [SerializeField] private UnityEvent OnStartTimer;
    [SerializeField] private UnityEvent OnMinigameFinished;

    public float PlayTime { get => time; set => time = value; }
    public bool TimerStarted { get; private set; } = false;

    private bool wonObjective = false;

    private void Start()
    {
        if (startOnAwake)
        {
            StartCoroutine(StartTimer());
        }
    }

    private void UpdateTextObject()
    {
        text.text = currentTime.ToString("#,00.00");
    }

    public IEnumerator StartTimer()
    {
        TimerStarted = true;
        currentTime = time;
        UpdateTextObject();

        OnStartTimer?.Invoke();

        while (currentTime >= 0)
        {
            yield return new WaitForEndOfFrame();
            currentTime -= Time.deltaTime;
            UpdateTextObject();
        }

        currentTime = 0;
        UpdateTextObject();

        manager.win = wonObjective;
        OnMinigameFinished?.Invoke();
    }

    //call this method when you finish the minigame
    public void CompleteObjective()
    {
        //StopAllCoroutines();
        wonObjective = true;
        TimerStarted = false;
    }
}
