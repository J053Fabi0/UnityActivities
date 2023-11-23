using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private float fallLimit = -10f;
    [SerializeField] private string[] deathTags = { "Trap", "Enemy" };

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        UpdateLivesText();
    }

    private void Update()
    {
        if (transform.position.y <= fallLimit && !GameManager.instance.isDying)
        {
            Die();
            GameManager.instance.isDying = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        for (int i = 0; i < deathTags.Length; i++)
        {
            if (collision.gameObject.CompareTag(deathTags[i]))
            {
                Die();
                GameManager.instance.isDying = true;
            }
        }

        if (collision.gameObject.CompareTag("Trophy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }

    private void Die()
    {
        GameManager.instance.lives--;
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
        UpdateLivesText();
    }

    private void UpdateLivesText()
    {
        livesText.text = "Lives: " + GameManager.instance.lives.ToString();
    }

    public void RestartLevel()
    {
        if (GameManager.instance.lives <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            return;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager.instance.isDying = false;
    }
}
