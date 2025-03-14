using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] int baseHP = 5;

    [Header("Refences")]
    [SerializeField] GameObject shieldPivot;

    private Camera mainCam;

    public static int shieldMode;
    public static int hp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = Camera.main;
        hp = baseHP;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 dir = (mousePos - Vector2.zero).normalized;
        var q = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, q - 90f);
    }
}
