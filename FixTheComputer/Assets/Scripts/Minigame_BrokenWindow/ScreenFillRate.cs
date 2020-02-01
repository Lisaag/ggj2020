using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFillRate : MonoBehaviour
{
    //[SerializeField] private Text percentageText; maybe put this somewhere very small
    [SerializeField] private ScriptableManager manager;
    [SerializeField] private Timer timer;
    [SerializeField] private int raycastDistance = 16;
    [SerializeField] [Range(0.1f, 1f)] private float checkingInterval = 0.25f;

    private bool completelyFilled = false;

    public float FillRatio { get; private set; } = 0;
    private float requiredFillRatio = 1;

    private void Awake()
    {
        switch (manager.difficulty)
        {
            case ScriptableManager.Difficulty.Easy:
                //timer.PlayTime = 10f;
                requiredFillRatio = 0.75f;
                break;
            case ScriptableManager.Difficulty.Medium:
                //timer.PlayTime = 7.5f;
                requiredFillRatio = 0.85f;
                break;
            case ScriptableManager.Difficulty.Hard:
                //timer.PlayTime = 5f;
                requiredFillRatio = 0.95f;
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

            int count = 0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (!Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(x * raycastDistance, y * raycastDistance))))
                    {
                        completelyFilled = false;
                    }
                    else
                    {
                        count++;
                    }
                }
            }

            FillRatio = (float) count / (width * height);
            //percentageText.text = (FillRatio * 100).ToString("#,00") + "%";

            //if (completelyFilled)
            if (FillRatio > requiredFillRatio) 
            {
                timer.CompleteObjective();
            }
        }
    } 
}
