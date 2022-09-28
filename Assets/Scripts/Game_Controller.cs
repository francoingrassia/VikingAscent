using UnityEngine;

public class Game_Controller: MonoBehaviour
{
    public int life = 3;
    public bool alive = true;

    private void Update()
    {
        if (life == 0)
        {
            alive = false;
        }
        Debug.Log(life);
    }
}
