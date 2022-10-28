using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] public GameObject OptionMenu;
    public void Jugar()
    {
        SceneManager.LoadScene(1);
    }
    public void Salir()
    {
        Application.Quit();
    }

    public void SalirOption()
    {
        OptionMenu.SetActive(false);
    }

    public void Option()
    {
        OptionMenu.SetActive(true);
    }

}
