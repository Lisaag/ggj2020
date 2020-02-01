using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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

    void Start()
    {
        difficulty = 6;
        typeText = this.GetComponent<TextMeshProUGUI>();
        typeChars = new char[difficulty];
        answerChars = new char[difficulty];
        answer = InitializeAnswerText();
        textMesh.text = answer;
        typeText.text = InitializeTypeText();
    }
    public static char GetLetter()
    {
        string chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&";
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
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Debug.Log("BACKSAPCE");
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
                    Debug.Log("WRONG");
                }
                Debug.Log("Going back");
                //TODO: Go back to main screen
            }
        }
    }

    bool EnterAnswer()
    {
        for(int i = 0; i < difficulty; i++)
        {
            if (typeChars[i] != answerChars[i])
            {
                Debug.Log(typeChars[i] + " != " + answerChars[i]);
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
