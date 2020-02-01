using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanagement : MonoBehaviour
{
    List<string> scenees = new List<string>();



    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addLists()
    {
        scenees.Clear();
        scenees.Add("FishingMinigame");
        scenees.Add("FortniteUninstallScene");
        scenees.Add("KeyboardMinigame");
        scenees.Add("phishingMail");
        scenees.Add("PostitMinigame");
        scenees.Add("TugOfWarMinigame");
        scenees.Add("WindowMinigame");
    }

    public void pickScene()
    {
        if (scenees.Count > 3)
        {
            string scene = scenees[Random.Range(0, scenees.Count)];
            {
                SceneManager.LoadScene(scene);
                scenees.Remove(scene);
            }
        }
        else
            SceneManager.LoadScene("Bricks");
    }
}
