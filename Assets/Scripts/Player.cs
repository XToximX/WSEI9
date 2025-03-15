using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] int baseHP = 5;

    [Header("Dupochron")]
    [SerializeField] float shieldTime = 1f;
    [SerializeField] float baseShieldCooldown = 5f;

    [Header("Refences")]
    [SerializeField] Transform shieldPivot;
    [SerializeField] SoundMgr soundMgr;
    public GameObject dupochron;

    [Header("PickUps")]
    [SerializeField] List<GameObject> pickUps;
    [SerializeField] float pickUpTime = 5f;

    private float shieldCooldown = 0f;

    private Camera mainCam;
    private SpriteRenderer shieldSprite;
    private SpriteRenderer secShieldSprite;


    [Space]
    [Space]
    [Space]
    public GameObject lvlUpMenu;
    public string shieldMode = "Tank";
    public int hp;
    public static bool powerUpActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = Camera.main;
        hp = baseHP;
        shieldSprite = GameObject.Find("ShieldSprite").GetComponent<SpriteRenderer>();
        secShieldSprite = pickUps[0].GetComponent<SpriteRenderer>();

        dupochron.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        shieldCooldown -= Time.deltaTime;

        Vector2 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 dir = (mousePos - Vector2.zero).normalized;
        var q = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if(!lvlUpMenu.activeSelf)
            shieldPivot.rotation = Quaternion.Euler(0f, 0f, q - 90f);

        //Dupochron
        if(Input.GetKeyDown(KeyCode.Space) && shieldCooldown < 0f && !dupochron.activeSelf)
        {
            StartCoroutine(Dupochron());
        }

        //Setting shield type
        if (Input.GetKeyDown(KeyCode.A))
        {
            shieldMode = "Tank";

            shieldSprite.color = Color.blue;
            secShieldSprite.color = Color.blue;

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            shieldMode = "Fast";

            shieldSprite.color = Color.red;
            secShieldSprite.color = Color.red;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Collect"))
            soundMgr.PlaySFX(4);

        if (collision.gameObject.CompareTag("Bullet") && hp > 0)
        {
            hp--;
            //Debug.Log("bum");
        }
        
        if (hp == 0)
        {
            //Debug.Log("BUM BUM");
        }
    }

    public void RandomPickUp()
    {
        StartCoroutine(PickUp(pickUps[(int)Mathf.Floor(Random.Range(0, (float)pickUps.Count - 0.01f))]));
    }

    public void lvlUpDupochron()
    {
        shieldCooldown -= 0.2f;
    }

    public void LvlUpShieldSize()
    {
        shieldSprite.transform.localScale += new Vector3(0.1f, 0f, 0f);
        secShieldSprite.gameObject.transform.localScale += new Vector3(0.1f, 0f, 0f);
    }

    IEnumerator Dupochron()
    {
        dupochron.SetActive(true);
        yield return new WaitForSeconds(shieldTime);
        dupochron.SetActive(false);
        shieldCooldown = baseShieldCooldown;
        soundMgr.PlaySFX(4);

    }

    IEnumerator PickUp(GameObject obj)
    {
        powerUpActive = true;
        obj.SetActive(true);
        yield return new WaitForSeconds(pickUpTime);
        powerUpActive = false;
        obj.SetActive(false);
    }
}
