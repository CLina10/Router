using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public const string levelName = "Level";

    void OnEnable()
    {
        MenuEvents.Instance.StartPlaying.AddListener(ChangeScene);
    }

    //void OnDisable()
    //{
    //    MenuEvents.Instance.StartPlaying.RemoveListener(ChangeScene);
    //}

    public void ChangeScene()
    {
        SceneManager.LoadScene("Level");
    }

    public void ChangeScene(string sceneName)
    {
    }
}
