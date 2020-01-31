using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private bool startOnAwake = true;
    [SerializeField] private float time = 5f;
    private float currentTime = float.PositiveInfinity;

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

    public IEnumerator StartTimer()
    {
        TimerStarted = true;
        currentTime = time;

        OnStartTimer?.Invoke();

        while (currentTime >= 0)
        {
            yield return new WaitForEndOfFrame();
            currentTime -= Time.deltaTime;
        }

        OnObjectiveFailed?.Invoke();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StopTimer();
        }
    }

    public void StopTimer()
    {
        StopAllCoroutines();
        TimerStarted = false;

        if (currentTime > 0)
        {
            OnObjectiveCompleted?.Invoke();
        }
    }
}
