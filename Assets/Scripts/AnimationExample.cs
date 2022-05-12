using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationExample : MonoBehaviour
{
    public Animation animation;
    public AnimationClip idle;
    public AnimationClip run;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            animation.clip = run;
            animation.Play(run.ToString());
        }
    }
}
