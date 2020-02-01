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

    private void Start()
    {
        downwardsDirection = bot.localPosition - top.localPosition;
        upwardsDirection = top.localPosition - bot.localPosition;
        currentDirection = downwardsDirection;
    }
    void Update()
    {
        
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
                            SceneManager.LoadScene("KeyboardMinigame");
                        }
                        Destroy(fishB.gameObject);
                    }
                }

                if (this.GetComponentInChildren<EnvelopeBehaviour>())
                {
                    Destroy(GetComponentInChildren<EnvelopeBehaviour>().gameObject);
                    manager.lives--;
                }

            }
        }
    }

    private void OnBecameInvisible()
    {
        this.transform.position = shootingPosition;
        currentDirection = downwardsDirection;
        hooking = false;
    }
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
        }
    }
}
