using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private bool isDying = false;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private float fallLimit = -10f;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        UpdateLivesText();
    }

    private void Update()
    {
        if (transform.position.y <= fallLimit && !isDying)
        {
            Die();
            isDying = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        GameManager.instance.lives--;
        UpdateLivesText();
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void UpdateLivesText()
    {
        livesText.text = "Lives: " + GameManager.instance.lives.ToString();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
