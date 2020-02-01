using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenFillRate : MonoBehaviour
{
    [SerializeField] private ScriptableManager manager;
    [SerializeField] private Timer timer;
    [SerializeField] private int raycastDistance = 16;
    [SerializeField] [Range(0.1f, 1f)] private float checkingInterval = 0.25f;

    private bool completelyFilled = false;

    private void Awake()
    {
        switch (manager.difficulty)
        {
            case ScriptableManager.Difficulty.Easy:
                timer.PlayTime = 10f;
                break;
            case ScriptableManager.Difficulty.Medium:
                timer.PlayTime = 7.5f;
                break;
            case ScriptableManager.Difficulty.Hard:
                timer.PlayTime = 5f;
                break;
        }
    }

    private void Start()
    {
        StartCoroutine(CheckForFillRate());
    }

    private IEnumerator CheckForFillRate()
    {
        while (!completelyFilled)
        {
            yield return new WaitForSeconds(checkingInterval);

            completelyFilled = true;

            int width = Mathf.FloorToInt(Screen.width / raycastDistance);
            int height = Mathf.FloorToInt(Screen.height / raycastDistance);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (!Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(x * raycastDistance, y * raycastDistance))))
                    {
                        completelyFilled = false;
                    }
                }
            }

            if (completelyFilled)
            {
                timer.CompleteObjective();
            }
        }
    } 
}
