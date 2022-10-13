using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
//Example movement using accelaration
public class SceneHandler : MonoBehaviour
{
    public void GameScene()
    {
        SceneManager.LoadScene("Game");
    }
    public void MenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}