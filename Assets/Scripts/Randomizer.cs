using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.Animations;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    [SerializeField] RuntimeAnimatorController[] skinsControllers;
    [SerializeField] SpriteRenderer sprtRndr;
    [SerializeField] Sprite[] backGroundSprite;
    Animator animatorComp;

    void Start()
    {
        animatorComp=GetComponent<Animator>();
        animatorComp.runtimeAnimatorController = skinsControllers[(int)Random.Range(0, 2)];
        sprtRndr.sprite = backGroundSprite[(int)Random.Range(0, 2)];
    }
}
