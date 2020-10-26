using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

public class Shopping : MonoBehaviour
{
    public Text MoneyT;

    [SerializeField]
    public GameObject Warning;

    public ListItem[] listItems;
    int money;
    int time = 3;

    int a = 0;
    int b = 0;
    int c = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        //////////////////for testing only//////////////////////
        //PlayerPrefs.SetInt("A", 0);
        //PlayerPrefs.SetInt("B", 0);
        //PlayerPrefs.SetInt("C", 1);
        //PlayerPrefs.SetInt("Chara", 2);
        //PlayerPrefs.SetInt("Currency", 0);
        //if (PlayerPrefs.GetInt("Currency") == null)
        //{
        //    PlayerPrefs.SetInt("Currency", 0);
        //}
        ///////////////////////////////////////////////
        if (PlayerPrefs.GetInt("Currency") != null)
        {
            money = PlayerPrefs.GetInt("Currency");
        }

        if (PlayerPrefs.GetInt("Chara") == null)
        {
            PlayerPrefs.SetInt("Chara", 2);
        }


    }

    // Update is called once per frame
    void Update()
    {
        money = PlayerPrefs.GetInt("Currency", money);
        MoneyT.text = Mathf.Round(money).ToString();
        ShoppingManager();
    }

    void ShoppingManager()
    {
        a = PlayerPrefs.GetInt("A");
        b = PlayerPrefs.GetInt("B");
        c = PlayerPrefs.GetInt("C");

        if (a == 1)
        {
            SetChange("Gura");
            PlayerPrefs.SetInt("Chara", 0);
        }

        if (b == 1)
        {
            SetChange("Indo");
            PlayerPrefs.SetInt("Chara", 1);
        }

        if (c == 1)
        {
            SetChange("Default");
            PlayerPrefs.SetInt("Chara", 2);
        }
    
    }

    public void BuyItemA()
    {
        if (money > 19)
        {
            money = money - 20;
            PlayerPrefs.SetInt("Currency", money);
            PlayerPrefs.SetInt("A", 1);
            ShoppingManager();
        }
        else
        {
            PlayerPrefs.SetInt("A", 0);
            warning();
        }
    }

    public void BuyItemB()
    {
        if (money > 19)
        {
            money = money - 20;
            PlayerPrefs.SetInt("B", 1);
            PlayerPrefs.SetInt("Currency", money);
            ShoppingManager();
        }
        else
        {
            PlayerPrefs.SetInt("B", 0);
            warning();
        }
    }

    public void BuyItemC()
    {
        if (money > 19)
        {
            money = money - 20;
            PlayerPrefs.SetInt("C", 1);
            PlayerPrefs.SetInt("Currency", money);
            ShoppingManager();
        }
        else
        {
            PlayerPrefs.SetInt("C", 0);
            warning();
        }
    }

    public void ChangeA()
    {
        SetUse(0);
        PlayerPrefs.SetInt("Chara", 0);
    }
    public void ChangeB()
    {
        SetUse(1);
        PlayerPrefs.SetInt("Chara", 1);
    }
    public void ChangeC()
    {

        SetUse(2);
        PlayerPrefs.SetInt("Chara", 2);
    }

    public void SetUse(int noArray)
    {
        foreach (ListItem L in listItems)
        {
            L.used.SetActive(false);
        }

        listItems[noArray].used.SetActive(true);

    }

    public void SetChange(string name)
    {
        ListItem li = Array.Find(listItems, ListItem => ListItem.name == name);
        if (li == null)
        {
            Debug.LogWarning("Item:" + name + "not found!");
            return;
        }
        li.ChangeB.SetActive(true);
        li.BuyB.SetActive(false);

    }

    //////////incomplete implementation//////////////
    void warning()
    {
        time = time - 1;
        while (time != 3)
        {
            time--;
            Warning.SetActive(true);
            if (time == 0)
            {
                Warning.SetActive(false);
                time = 3;
            }
            //yield return new WaitForEndOfFrame();
        }
    }
    ///////////////////////////////////////////////


    
}
