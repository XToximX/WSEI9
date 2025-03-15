using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] float speed = 2f;
    [SerializeField] LayerMask shieldLayer;

    public string bulletType;
    private Transform player;
    private Player playerScript;
    private Rigidbody2D rb;
    private float lastHit = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        playerScript = player.GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        

        var dir = player.position - transform.position;
        rb.linearVelocity = dir.normalized * speed;

        var q = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, q - 90f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x) > 15 || Mathf.Abs(transform.position.y) > 10)
            Destroy(gameObject);

        lastHit -= Time.deltaTime;

        var hit = Physics2D.OverlapCircle(transform.position, .37f, shieldLayer);

        if (hit != null && lastHit < 0f)
        {
            if (hit.gameObject.CompareTag("Enemy"))
            {
                hit.gameObject.SetActive(false);
                Reflect();
            }
            else if (playerScript.shieldMode == bulletType || hit.CompareTag("Dupochron"))
            {
                Reflect();
                if(!playerScript.dupochron.activeSelf)
                    ScoreCounter.AddScore(50);
                else
                    ScoreCounter.AddScore(10);
                ScoreCounter.bulletsReflected += 1;
                //GameObject.Find("SoundMgr").GetComponent<SoundMgr>().PlaySFX(3);

            }
            else
            {
                ScoreCounter.AddScore(25);
                Destroy(gameObject);
            }
            lastHit = 1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Shield") || collision.gameObject.CompareTag("Dupochron"))
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
