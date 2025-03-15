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
            ScoreCounter.combo += 2;
            ScoreCounter.AddScore(200);
            ScoreCounter.collectibles++;
            collision.gameObject.GetComponent<Player>().RandomPickUp();
        }
        if(collision.gameObject.CompareTag("Shield"))
        {
            GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundMgr>().PlaySFX(7);
            ScoreCounter.ComboBreak();
        }
        Destroy(gameObject);
    }
}