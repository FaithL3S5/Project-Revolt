using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharManager : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;

    public RuntimeAnimatorController[] anim;
    int Chara;
    public Sprite[] spriteArray;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (PlayerPrefs.GetInt("Chara") == null)
        {
            PlayerPrefs.SetInt("Chara", 2);
        }

        if (PlayerPrefs.GetInt("Chara") != null)
        {
            Chara = PlayerPrefs.GetInt("Chara");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Chara = PlayerPrefs.GetInt("Chara");

        if (Chara == 0)
        {
            spriteRenderer.sprite = spriteArray[0];
            this.GetComponent<Animator>().runtimeAnimatorController = anim[0] as RuntimeAnimatorController;
        }

        if (Chara == 1)
        {
            spriteRenderer.sprite = spriteArray[1];
            this.GetComponent<Animator>().runtimeAnimatorController = anim[1] as RuntimeAnimatorController;
        }

        if (Chara == 2)
        {
            spriteRenderer.sprite = spriteArray[2];
            this.GetComponent<Animator>().runtimeAnimatorController = anim[2] as RuntimeAnimatorController;
        }
    }
}
