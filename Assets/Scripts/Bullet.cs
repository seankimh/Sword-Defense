using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f; // Bullet speed
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject); // Destroy if player is missing
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sword"))
        {
            Debug.Log("Bullet destroyed by Sword!");
            GameManager.Instance.IncreaseScore(); // Increase Score
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Player"))
        {
            Debug.Log("Bullet hit the player! Game Over!");
            GameManager.Instance.GameOver(); // Game Over & High Score Update
        }
    }

}
