using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class DeathSceneManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    public GameObject retryButton;
    public GameObject quitButton;

    void Start()
    {
        retryButton.SetActive(false);
        quitButton.SetActive(false);

        videoPlayer.loopPointReached += ShowButtons;
    }

    void ShowButtons(VideoPlayer vp)
    {
        retryButton.SetActive(true);
        quitButton.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }



    public void RetryGame() { SceneManager.LoadScene("F0"); }
    public void QuitGame()
    {
        Debug.Log("Game Quit");

        // บรรทัดนี้จะทำให้ Unity Editor หยุดรัน (ใช้เช็คแทนการปิดเกมจริง)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}