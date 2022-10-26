using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField userNameInput;
    [SerializeField] private GameObject bestScoreText;

    private void Start()
    {
        userNameInput.onEndEdit.AddListener(SetName);
        bestScoreText.GetComponent<TextMeshProUGUI>().SetText("Best Score is " + ScoreManager.Instance.HighScore);
        bestScoreText.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SetName(string username)
    {
        Debug.Log("The user name entered in menu screen is " + username);
        ScoreManager.Instance.UserName = username;
    }
}
