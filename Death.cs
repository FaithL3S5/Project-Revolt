using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Death : MonoBehaviour
{
    [SerializeField]
    public GameObject LosePanel;

    public AudioManager AM;
    public Money Mny;

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
            rb2d.velocity = new Vector2(0, 0);
               
        if (col.gameObject.CompareTag("Obstacle"))
        {
            Mny.Save();
            AM.Play("Crash");
            Time.timeScale = 0;
            Debug.Log("Hit");
            LosePanel.SetActive(true);
            AM.Stop();
        }
    }
}
