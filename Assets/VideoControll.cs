using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoControll : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName = "F0";

    void Start()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoEnd;
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextSceneName);
    }
}