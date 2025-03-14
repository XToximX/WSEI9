using UnityEngine;

public class CollectiveDestroy : MonoBehaviour
{
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
