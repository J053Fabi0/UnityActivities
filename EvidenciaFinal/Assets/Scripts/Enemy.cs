using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    // initial position
    private Vector3 initialPosition;
    // distance from initial position to move to
    [SerializeField] private float distance = 2f;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isDying)
        {
            return;
        }

        // move enemy
        transform.Translate(speed * Time.deltaTime * Vector3.right);
        // check if enemy has moved past distance
        if (speed > 0 && transform.position.x >= initialPosition.x + distance)
        {
            // change direction
            speed *= -1;
        }
        else if (speed < 0 && transform.position.x <= initialPosition.x - distance)
        {
            // change direction
            speed *= -1;
        }

        // flip sprite
        sr.flipX = speed < 0;
    }
}
