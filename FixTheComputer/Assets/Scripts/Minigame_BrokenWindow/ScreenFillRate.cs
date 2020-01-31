using System.Collections;
using UnityEngine;

public class ScreenFillRate : MonoBehaviour
{
    [SerializeField] private int raycastDistance = 16;
    [SerializeField] [Range(0.1f, 1f)] private float checkingInterval = 0.25f;

    private bool completelyFilled = false;

    private void Start()
    {
        StartCoroutine(CheckForFillRate());
    }

    //this doesnt work
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
                    if (!Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(x * width, y * width))))
                    {
                        completelyFilled = false;
                    }
                }
            }

            if (completelyFilled)
            {
                Debug.Log("wow its actually filled"); //finish game 
            }
        }
    } 
}
