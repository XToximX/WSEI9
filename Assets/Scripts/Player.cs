using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] int baseHP = 5;

    [Header("Refences")]
    [SerializeField] GameObject shieldPivot;

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
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 dir = (mousePos - Vector2.zero).normalized;
        var q = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, q - 90f);


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
}
