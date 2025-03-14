using UnityEngine;

public class CollectiveDestroy : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0f, 0f, 0.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ScoreCounter.AddScore(200);
            collision.gameObject.GetComponent<Player>().RandomPickUp();
        }
        Destroy(gameObject);
    }
}