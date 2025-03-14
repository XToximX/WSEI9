using UnityEngine;

public class DestroyBulletInside : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
            Destroy(collision.gameObject);
    }
}
