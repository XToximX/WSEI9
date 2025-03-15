using UnityEngine;

public class Heal : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gameObject.SetActive(false);
    }

    void Update()
    {
        player.hp++;
        gameObject.SetActive(false);
    }
}
