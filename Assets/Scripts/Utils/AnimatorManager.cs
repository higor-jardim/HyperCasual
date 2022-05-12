using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator animator;
    public List<AnimatorSetup> animatorSteups;
    public enum AnimationType
    {
        IDLE,
        RUN,
        DEAD
    }

    public void Play(AnimationType type, float currentSpeedFactor = 1)
    {
        foreach(var animation in animatorSteups)
        {
            if (animation.type == type)
            {
                animator.SetTrigger(animation.trigger);
                animator.speed = animation.speed * currentSpeedFactor;
                break;
            }
        }
    }

    
    void Update()
    {
        
    }

    [System.Serializable]
    public class AnimatorSetup
    {
        public AnimatorManager.AnimationType type;
        public string trigger;
        public float speed = 1f;
    }
}
