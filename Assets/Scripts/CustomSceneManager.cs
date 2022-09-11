using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    public static CustomSceneManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            return;
        }
        else
        {
            instance = this;
        }
    }

    public void ChangeToGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void ChangeToMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
