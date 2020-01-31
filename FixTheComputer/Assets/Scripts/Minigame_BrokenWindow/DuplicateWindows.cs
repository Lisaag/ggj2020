using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicateWindows : MonoBehaviour
{
    [SerializeField] private Transform original;
    [SerializeField] private int objectPoolSize;
    [SerializeField] [Range(0.0167f, 1f)] private float refreshTime = 0.0167f;

    private List<Transform> objects;
    private int currentIndex = 0;

    private Vector3 offset = new Vector3(0, 0, 0.001f);

    public bool PlayingMinigame { get; set; } = true;

    private void Start()
    {
        Debug.Log(Screen.width + ", " + Screen.height);

        objects = new List<Transform>();
        for (int i = 0; i < objectPoolSize; i++)
        {
            GameObject go = Instantiate(original.gameObject, transform);
            go.SetActive(false);
            objects.Add(go.transform);
        }

        StartCoroutine(UpdatePrefabAvailability());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayingMinigame = !PlayingMinigame;
        }
    }

    private IEnumerator UpdatePrefabAvailability()
    {
        while (true)
        {
            yield return new WaitForSeconds(refreshTime);

            if (PlayingMinigame)
            {
                if (currentIndex >= objectPoolSize)
                {
                    currentIndex = 0;
                }

                objects[currentIndex].gameObject.SetActive(true);
                if (currentIndex - 1 >= 0)
                {
                    objects[currentIndex - 1].position -= offset;
                }
                else
                {
                    objects[objectPoolSize - 1].position -= offset;
                }
                objects[currentIndex++].position = original.position + offset * 2;
                //offset.z += 0.001f;
            }
        }
    }
}
