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
    [SerializeField] private Text text;

    [Header("Timer Started Events")]
    [SerializeField] private UnityEvent OnStartTimer;

    [Header("Timer Finished Events")]
    [SerializeField] private UnityEvent OnObjectiveCompleted;
    [SerializeField] private UnityEvent OnObjectiveFailed;

    public bool TimerStarted { get; private set; } = false;

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

        OnObjectiveFailed?.Invoke();
    }

    //call this method when you finished the minigame
    public void CompleteObjective()
    {
        StopAllCoroutines();
        TimerStarted = false;

        if (currentTime > 0)
        {
            OnObjectiveCompleted?.Invoke();
        }
    }
}
