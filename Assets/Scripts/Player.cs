using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] int baseHP = 5;

    [Header("Dupochron")]
    [SerializeField] float shieldTime = 1f;
    [SerializeField] float baseShieldCooldown = 5f;

    [Header("Refences")]
    [SerializeField] GameObject shieldPivot;
    public GameObject dupochron;

    
    private float shieldCooldown = 0f;


    private Camera mainCam;
    private SpriteRenderer shieldSprite;

    public string shieldMode;
    public static int hp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = Camera.main;
        hp = baseHP;
        shieldSprite = GameObject.Find("ShieldSprite").GetComponent<SpriteRenderer>();

        dupochron.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        shieldCooldown -= Time.deltaTime;

        Vector2 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 dir = (mousePos - Vector2.zero).normalized;
        var q = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, q - 90f);

        //Dupochron
        if(Input.GetKeyDown(KeyCode.Space) && shieldCooldown < 0f && !dupochron.activeSelf)
        {
            StartCoroutine(Dupochron());
        }

        //Setting shield type
        if (Input.GetKeyDown(KeyCode.W))
        {
            shieldMode = "Tank";
            shieldSprite.color = Color.blue;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            shieldMode = "Fast";
            shieldSprite.color = Color.red;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && hp > 0)
        {
            hp--;
            Debug.Log("bum");
        }
        
        if (hp == 0)
        {
            Debug.Log("BUM BUM");
        }
            
    }

    IEnumerator Dupochron()
    {
        dupochron.SetActive(true);
        yield return new WaitForSeconds(shieldTime);
        dupochron.SetActive(false);
        shieldCooldown = baseShieldCooldown;
    }
}
