using UnityEngine;


public class DestroyAfter : MonoBehaviour
{
    [SerializeField] private float timeLeft;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft < 0f)
            Destroy(gameObject);
    }
}
