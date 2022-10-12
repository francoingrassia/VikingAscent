using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool option = false;
    [SerializeField] public GameObject OptionMenu;
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Salir()
    {
        Application.Quit();
    }

    public void Option()
    {
        OptionMenu.SetActive(true);
    }
}
