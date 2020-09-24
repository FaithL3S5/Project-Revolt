using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Death : MonoBehaviour
{
    [SerializeField]
    public GameObject LosePanel;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.CompareTag("Obstacle"))
        {
            Time.timeScale = 0;
            Debug.Log("Hit");
            LosePanel.SetActive(true);
        }
    }
}
