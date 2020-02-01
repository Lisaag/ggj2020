using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicateWindows : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private int audioInterval;
    [SerializeField] private Transform original;
    [SerializeField] private int objectPoolSize;
    [SerializeField] [Range(0.0167f, 1f)] private float refreshTime = 0.0167f;

    private List<Transform> objects;
    private int currentIndex = 0;

    private Vector3 offset = new Vector3(0, 0, 0.001f);


    private void Awake()
    {
        objects = new List<Transform>();
        for (int i = 0; i < objectPoolSize; i++)
        {
            GameObject go = Instantiate(original.gameObject, transform);
            go.SetActive(false);
            objects.Add(go.transform);
        }
    }

    public void StartMinigame()
    {
        StartCoroutine(UpdatePrefabAvailability());
    }

    //de offset klopt niet helemaal, maar is goed genoeg voor nu. fix later wanneer belangrijkere dingen klaar zijn.
    private IEnumerator UpdatePrefabAvailability()
    {
        int currentInterval = 0;
        while (true)
        {
            yield return new WaitForSeconds(refreshTime);

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

            if (++currentInterval % audioInterval == 0)
            {
                audioSource?.Play();
            }
        }
    }
}
