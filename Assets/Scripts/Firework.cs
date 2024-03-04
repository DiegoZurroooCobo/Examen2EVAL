using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firework : MonoBehaviour
{
    public float force, minTimeToExplode, maxTimeToExplode;
    public int minFireworks, maxFireworks;
    public GameObject fireworkPrefab;
    public int maxExplosions = 3;

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
        _rb.AddForce(force * _dir, ForceMode2D.Impulse);
        _rend.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f), 1f);
        currentTime = 0;
        timeToExplode = Random.Range(minTimeToExplode, maxTimeToExplode);
    }
    private void Update()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= timeToExplode)
        {
            if (_count < maxExplosions)
            {
                int rndFW = Random.Range(minFireworks, maxFireworks);
                for (int i = 0; i < rndFW; i++)
                {
                    Firework fw = Instantiate(fireworkPrefab, transform.position, Quaternion.identity).gameObject.GetComponent<Firework>();
                    fw._dir = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
                    fw._count += _count + 1;
                }
            }
            Destroy(gameObject);
        }
    }
}
