using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public int lives = 3;
    // is the player currently showing the death animation?
    public bool isDying = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}