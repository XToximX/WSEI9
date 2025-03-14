using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] float speed = 2f;
    [SerializeField] LayerMask shieldLayer;


    private Transform player;
    private Rigidbody2D rb;
    private float lastHit = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

        var dir = player.position - transform.position;
        rb.linearVelocity = dir.normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        lastHit= Time.deltaTime;

        if(Physics2D.OverlapCircle(transform.position, .2f, shieldLayer) != null && lastHit < 0f)
        {
            lastHit = 1f;
            Reflect();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(2);
    }

    private void Reflect()
    {
        rb.linearVelocity *= -1;

    }
}
