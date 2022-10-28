using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject OptionMenu;
    [SerializeField] public GameObject Pause;
    [SerializeField] public Game_Controller Game;

    public void MainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
    public void Salir()
    {
        Application.Quit();
    }

    public void Option()
    {
        OptionMenu.SetActive(true);
    }
    public void Resume()
    {
        Game.paused = false;

    }
}
