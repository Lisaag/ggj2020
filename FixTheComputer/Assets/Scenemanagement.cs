using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanagement : MonoBehaviour
{
    public static Scenemanagement instance;

    public List<string> scenees = new List<string>();
    public bool firstLevel = true;
    public string scene;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        addLists();
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
        if (firstLevel)
        {
            firstLevel = false;
            SceneManager.LoadScene("MainScreen");
        }

        else if (scenees.Count > 3)
        {
            {
                scene = scenees[Random.Range(0, scenees.Count)];                
                scenees.Remove(scene);
                SceneManager.LoadScene(scene);
            }
        }
        
        else
        SceneManager.LoadScene("Bricks");

    }
}
