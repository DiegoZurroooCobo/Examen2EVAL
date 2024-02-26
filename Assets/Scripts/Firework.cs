using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firework : MonoBehaviour
{
    public float force, minTimeToExplode, maxTimeToExplode;
    public int minFireworks, maxFireworks;
    public GameObject fireworkPrefab;
    public int maxExplosions = 3;
    public Color[] colors = new Color[5];

    private Rigidbody2D _rb;
    private SpriteRenderer _rend;
    private int _count = 0;
    private Vector2 _dir = Vector2.up;
    private float currentTime, timeToExplode;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rend = GetComponent<SpriteRenderer>();
        GameManager.instance.SetFireworks(GameManager.instance.GetFireworks() + 1);
        _rb.AddForce(Vector2.up * force * _rb.gravityScale, ForceMode2D.Impulse);
        _rend.color = colors[0];
        Random.Range(colors.Length, colors.Length);
        currentTime = 0;
        timeToExplode = Random.Range(minTimeToExplode, maxTimeToExplode);
    }
    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= timeToExplode) 
        {
            Destroy(gameObject);
        }    
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(currentTime >= maxTimeToExplode) 
        { 
            if(maxExplosions >= 1) 
            {
               maxExplosions++;
               GameObject FireWorks = Instantiate(fireworkPrefab, transform.position, Quaternion.identity);
               FireWorks.GetComponent<Firework>();
               _dir.x = Random.Range(-1, 2);
               _dir.y = Random.Range(-1, 2);
            }

            Destroy(gameObject);
        }
    }
}
