using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //publics
    [Header("Lerp Speed")]
    public Transform target;
    public float lerpSpeed = 1f;

    public float speed = 1f;

    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckFinishLine = "FinishLine";

    public GameObject endScreen;

    //privates
    private bool _canrun;
    private Vector3 _pos;

    

    
    void Update()
    {
       if (!_canrun) return;


       _pos = target.position;
       _pos.y = transform.position.y;
       _pos.z = transform.position.z;
    
       transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime); 
       transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagToCheckEnemy)
        {
            EndGame();
        }

        if (collision.transform.tag == tagToCheckFinishLine)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        _canrun = false;
        endScreen.SetActive(true);
    }

    public void StartToRun()
    {
        _canrun = true;
    }
}
