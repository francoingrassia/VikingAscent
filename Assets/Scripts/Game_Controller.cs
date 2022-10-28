using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Controller: MonoBehaviour
{
    [SerializeField] public GameObject OptionMenu;
    [SerializeField] public GameObject Pause;
    [SerializeField] Animator Heart1;
    [SerializeField] Animator Heart2;
    [SerializeField] Animator Heart3;
    [SerializeField] SoundController sound;
    [SerializeField] Image fade;
    


    public int life = 3;
    public bool alive = true;
    public bool paused = false;

    private void Start()
    {
        fade.color = new Color(0, 0, 0, 1);
    }

    private void Update()
    {
        switch (life)
        {

            case 2:
                Heart1.SetTrigger("Damage");
                break;
            case 1:
                Heart2.SetTrigger("Damage");
                break;
            case 0:
                Heart3.SetTrigger("Damage");
                sound.SeleccionAudio(7, 0.2f);
                alive = false;
                life = -5;
                break;

        }

        if (paused)
        {
            Time.timeScale = 0;
            Pause.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            OptionMenu.SetActive(false);
            Pause.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape)){
            paused = !paused;
        }
        
    }
    private void FixedUpdate()
    {
        if (!alive)
        {
            FadeEffect(1);
            if (fade.color.a > 0.95f)
            {
                SceneManager.LoadScene(1);
            }
        }
        else
        {
            FadeEffect(0);
        }
    }

    public void FadeEffect(float valorDeseado)
    {
        float valorFade = Mathf.Lerp(fade.color.a, valorDeseado, .05f);
        fade.color = new Color(0, 0, 0, valorFade);
    }

    
}
