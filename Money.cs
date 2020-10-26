using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    
    public Text scoreText;
	int money;

    int collected;
	
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Currency") != null)
        {
            money = PlayerPrefs.GetInt("Currency");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
		scoreText.text = "x " + Mathf.Round(collected).ToString();
    }

    public int Collect()
    {
        return collected;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Currency", money);
    }
	
	private void OnTriggerEnter2D(Collider2D col){
      if(col.gameObject.CompareTag("Collectible")){
           Destroy(col.gameObject);
		   money++;
           collected++;
                    
      }
	}
	
}
