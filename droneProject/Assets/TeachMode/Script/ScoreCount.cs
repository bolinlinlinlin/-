using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    public static int score;
    public Animator animator;
    public Animator wasd;
    public Animator ijkl;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("anmscore", score);
        wasd.SetInteger("wasd", score);
        ijkl.SetInteger("ijkl", score);
    }
}