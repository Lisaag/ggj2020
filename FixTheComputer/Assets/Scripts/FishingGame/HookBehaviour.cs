using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HookBehaviour : MonoBehaviour
{
    public float hookSpeed;
    public Transform top;
    public Transform bot;
    public bool hooking;
    Vector3 downwardsDirection;
    Vector3 upwardsDirection;
    Vector3 currentDirection;
    public Vector3 shootingPosition;
    public int fishiesCaught;
    public ScriptableManager manager;
    public GameObject badCatch;
    public GameObject goodCatch;
    public GameObject livesParent;
    List<GameObject> lives = new List<GameObject>();
    public GameObject goodGame;
    public GameObject badGame;
    public List<GameObject> stupidThings = new List<GameObject>();
    public bool isOverNya;

    private void Start()
    {
        downwardsDirection = bot.localPosition - top.localPosition;
        upwardsDirection = top.localPosition - bot.localPosition;
        currentDirection = downwardsDirection;
        foreach(Transform t in livesParent.transform)
        {
            lives.Add(t.gameObject);
        }
    }
    void RemoveLife()
    {
        int livesActive = 3;
        foreach(GameObject go in lives)
        {
            if (go.activeInHierarchy)
            {
                go.SetActive(false);
                break;
            }
            livesActive--;
        }
        if (livesActive == 1)
        {
            StartCoroutine(LoadNextScene());
        }
    }

    void MoveEverything()
    {
        foreach (GameObject go in stupidThings)
        {
            //go.transform.position += new Vector3(0, 50f, 0);
            go.transform.localEulerAngles += new Vector3(0, 2f, 0);
        }
    }
    IEnumerator LoadNextScene()
    {
        isOverNya = true;
        if (fishiesCaught == 5)
        {
            goodGame.SetActive(true);
        }
        else
        {
            badGame.SetActive(true);
        }
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("KeyboardMinigame");
    }
    void Update()
    {
        if (isOverNya)
        {
            MoveEverything();
        }

        //if (this.transform.localPosition.y < -25f)
        //{
        //    hooking = false;
        //    this.transform.position = shootingPosition;
        //}
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (this.GetComponentInChildren<FishBehaviour>() != null || this.GetComponentInChildren<EnvelopeBehaviour>() != null)
            {
                return;
            }
            if (!hooking)
            {
                shootingPosition = this.transform.position;
                hooking = true;
                return;
            }
            else if (hooking)
            {
                hooking = false;
                this.transform.position = shootingPosition;
            }
        }
        if (hooking)
        {
            transform.Translate(currentDirection * Time.deltaTime * hookSpeed);
            transform.localEulerAngles += new Vector3(0, 1f, 0);
            if (this.transform.position.y > shootingPosition.y)
            {
                hooking = false;
                this.transform.position = shootingPosition;
                currentDirection = downwardsDirection;
                if (this.GetComponentInChildren<FishBehaviour>() != null)
                {
                    foreach(FishBehaviour fishB in this.GetComponentsInChildren<FishBehaviour>())
                    {
                        fishiesCaught += 1;
                        if (fishiesCaught == 5)
                        {
                            StartCoroutine(LoadNextScene());
                        }
                        if (goodCatch.activeInHierarchy)
                        {
                            goodCatch.SetActive(false);
                        }
                        goodCatch.SetActive(true);
                        Destroy(fishB.gameObject);
                    }
                }

                if (this.GetComponentInChildren<EnvelopeBehaviour>())
                {
                    Destroy(GetComponentInChildren<EnvelopeBehaviour>().gameObject);
                    manager.lives--;
                    if (badCatch.activeInHierarchy)
                    {
                        badCatch.SetActive(false);
                    }
                    badCatch.SetActive(true);
                    RemoveLife();
                }
            }
        }
    }

    //private void OnBecameInvisible()
    //{
    //    this.transform.position = shootingPosition;
    //    currentDirection = downwardsDirection;
    //    hooking = false;
    //}
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colliding");
        if (other.transform.CompareTag("Fish"))
        {
            currentDirection = upwardsDirection;
            other.transform.parent = this.transform;
            other.gameObject.GetComponent<FishBehaviour>().Stop();
        }

        if (other.transform.CompareTag("Envelope"))
        {
            currentDirection = upwardsDirection;
            other.transform.parent = this.transform;
            other.GetComponent<EnvelopeBehaviour>().move = false;
        }

        if (other.transform.CompareTag("Borders"))
        {
            this.transform.position = shootingPosition;
            currentDirection = downwardsDirection;
            hooking = false;
        }
    }
}
