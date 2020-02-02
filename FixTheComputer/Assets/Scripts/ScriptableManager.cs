using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class ScriptableManager : ScriptableObject
{
    public int lives;
    public Difficulty difficulty;
    public bool win;
    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }

    private void OnEnable()
    {
        lives = 3;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
