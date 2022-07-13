using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem particleSystem;
    public float timeToHide = 3f;
    public float timeToRespawn = 3f;
    public GameObject graphicItem;

    [Header("Sounds")]
    public AudioSource audioSource;



    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void HideItems()
    {
        if (graphicItem != null) graphicItem.SetActive(false);
        Invoke("HideObject", timeToHide);
        //Invoke("RespawnObject", timeToRespawn);
    }

    protected virtual void Collect()
    {
        HideItems();
        OnCollect();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    private void RespawnObject()
    {
        gameObject.SetActive(true);
    }

    protected virtual void OnCollect()
    {
        if (particleSystem != null)
        {
            particleSystem.transform.SetParent(null);
            particleSystem.Play();
        }

        if (audioSource != null) audioSource.Play();
    }
}
