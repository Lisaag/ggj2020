using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LetterBehaviour : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    TextMeshProUGUI typeText;
    string answer = "";
    int difficulty;
    char[] typeChars;
    char[] answerChars;
    int currentChar;
    public ScriptableManager scriptM;
    public Timer timer;
    public TextMeshProUGUI winloseText;
    bool gameOver;

    void SetDifficulty()
    {
        if (scriptM.difficulty == ScriptableManager.Difficulty.Easy)
        {
            difficulty = 5;
        }
        if (scriptM.difficulty == ScriptableManager.Difficulty.Medium)
        {
            difficulty = 7;
        }
        if (scriptM.difficulty == ScriptableManager.Difficulty.Hard)
        {
            difficulty = 9;
        }
    }
    void Start()
    {
        SetDifficulty();
        typeText = this.GetComponent<TextMeshProUGUI>();
        typeChars = new char[difficulty];
        answerChars = new char[difficulty];
        answer = InitializeAnswerText();
        textMesh.text = answer;
        typeText.text = InitializeTypeText();
    }
    public static char GetLetter()
    {
        string chars = "$%#@!*abcdefhijkmnopqrstuvwxyz123456789?;:ABCDEFGHJKLMNOPQRSTUVWXYZ^&"; //excluded g and zero^and l (L) and I
        int num = Random.Range(0, chars.Length);
        return chars[num];
    }

    public string GetStringedLetter(int i)
    {
        char c = GetLetter();
        answerChars[i] = c;
        return "" + c + " ";
    }

    void Update()
    {
        if (gameOver)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (currentChar != 0)
            {
                currentChar--;
            }
            typeChars[currentChar] = '_';
            UpdateAnswerText();
            return;
        }
        if (Input.inputString != "" && Input.inputString != " " && !Input.GetKey(KeyCode.Backspace))
        {

            char[] currentInput = Input.inputString.ToCharArray();
            typeChars[currentChar] = currentInput[0];
            currentChar++;
            UpdateAnswerText();
            if (currentChar == difficulty)
            {
                if (!EnterAnswer())
                {
                    winloseText.text = "Wrong answer!";
                    scriptM.win = false;
                    StartCoroutine(WinOrLose("InBetween"));//TODO: Add next screen
                    gameOver = true;
                    scriptM.lives--;
                    return;
                }
                scriptM.win = true;
                winloseText.text = "Good job!";
                gameOver = true;
                StartCoroutine(WinOrLose("InBetween")); //TODO: Add next screen

            }
        }
    }
    public void TimesUp()
    {
        if (!winloseText.gameObject.activeInHierarchy)
        {
            winloseText.text = "Time's up";
            gameOver = true;
            StartCoroutine(WinOrLose(""));//TODO: Add next screen
        }
    }
    IEnumerator WinOrLose(string nextScene)
    {
        winloseText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(nextScene);
    }
    bool EnterAnswer()
    {
        for(int i = 0; i < difficulty; i++)
        {
            if (typeChars[i] != answerChars[i])
            {
                return false;
            }
        }
        return true;
    }
    string InitializeAnswerText()
    {
        string s = "";
        for (int i = 0; i < difficulty; i++)
        {
            s += GetStringedLetter(i);
        }
        return s;
    }
    string InitializeTypeText()
    {
        string s = "";
        for (int i = 0; i < difficulty; i++)
        {
            typeChars[i] = '_';
            s += typeChars[i] + " ";
        }
        return s;
    }

    void UpdateAnswerText()
    {
        string s = "";
        for(int i = 0; i < difficulty; i++)
        {
            s += typeChars[i] + " ";
        }
        typeText.text = s;
    }
}
