using UnityEngine.SceneManagement;
using UnityEngine;

public class EndpanelController : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void BackToGame()
    {
        gameObject.SetActive(false);
    }
}
