using UnityEngine;

public class BulletDestory : MonoBehaviour
{
    private void OnCollisionExit2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }
}
