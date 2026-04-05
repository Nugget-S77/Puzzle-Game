using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class EndingSceneManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject retryButton;
    public GameObject quitButton;

    void Start()
    {
        retryButton.SetActive(false);
        quitButton.SetActive(false);

        videoPlayer.loopPointReached += ShowEndButtons;
    }

    void ShowEndButtons(VideoPlayer vp)
    {
        retryButton.SetActive(true);
        quitButton.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("F0");
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}