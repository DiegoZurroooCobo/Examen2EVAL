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
    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rend = GetComponent<SpriteRenderer>();
        GameManager.instance.SetFireworks(GameManager.instance.GetFireworks() + 1);
        _dir = new Vector2(0, 1);
         Random.Range(colors.Length, colors.Length);
        _rend.color = colors[0];
        currentTime = 0;
    }
    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= maxTimeToExplode) 
        {
            Random.Range(minTimeToExplode, maxTimeToExplode);
            Destroy(gameObject);
        }    

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(currentTime >= maxTimeToExplode) 
        { 
            
        }
    }
}
