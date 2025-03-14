using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] float speed = 2f;
    [SerializeField] LayerMask shieldLayer;

    public string bulletType;
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
        if (Mathf.Abs(transform.position.x) > 15 || Mathf.Abs(transform.position.y) > 10)
            Destroy(gameObject);

        lastHit -= Time.deltaTime;

        var hit = Physics2D.OverlapCircle(transform.position, .3f, shieldLayer);

        if (hit != null && lastHit < 0f)
        {
            if (hit.gameObject.CompareTag("Enemy"))
            {
                hit.gameObject.SetActive(false);
                Reflect();
            }
            else if (player.gameObject.GetComponent<Player>().shieldMode == bulletType)
                Reflect();
            else
                Destroy(gameObject);
            lastHit = 1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Destroy(gameObject);
    }

    private void Reflect()
    {
        rb.linearVelocity *= -1;
    }

    public void SetType(string enemyType)
    {
        bulletType = enemyType;

        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        switch (bulletType)
        {
            case "Tank":
                sprite.color = Color.blue;
                break;
            case "Fast":
                sprite.color = Color.red;
                break;
        }

    }
}
