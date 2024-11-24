using UnityEngine;
using TMPro;  // TextMeshPro namespace
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;  // To exit PlayMode in the editor
#endif

public class StartMenuManager : MonoBehaviour
{
    public TMP_InputField playerNameInput;  // Reference to the TMP_InputField
    public Button saveButton;               // Reference to the Button for Save
    public Button quitButton;               // Reference to the Button for Quit

    private void Start()
    {
        // Attach button listeners
        saveButton.onClick.AddListener(SavePlayerName);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void SavePlayerName()
    {
        string playerName = playerNameInput.text;
        PlayerPrefs.SetString("PlayerName", playerName);  // Save the player name using PlayerPrefs
        PlayerPrefs.Save();

        // Load the next scene (Main Game scene)
        SceneManager.LoadScene(0);
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        // If in the Unity editor, stop playmode
        EditorApplication.isPlaying = false;
#else
        // If in a built game, quit the application
        Application.Quit();
#endif
    }
}
