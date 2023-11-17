using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private int cherries = 0;

    [SerializeField] private TextMeshProUGUI cherriesText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "Cherries: " + cherries.ToString();
        }
    }
}
