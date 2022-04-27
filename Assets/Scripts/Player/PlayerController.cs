using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;

public class PlayerController : Singleton<PlayerController>
{
    //publics
    [Header("Lerp Speed")]
    public Transform target;
    public float lerpSpeed = 1f;

    public float speed = 1f;

    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckFinishLine = "FinishLine";

    public GameObject endScreen;

    [Header("Text")]
    public TextMeshPro uiTextPowerUp;


    public bool Invicibility = true;

    //privates
    private bool _canrun;
    private Vector3 _pos;
    private float _currentspeed;

    private void Start()
    {
        ResetSpeed();

    }


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
           if(Invicibility) EndGame();
        }

        if (collision.transform.tag == tagToCheckFinishLine)
        {
            if (Invicibility) EndGame();
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

    #region POWER UPS

    public void SetPowerUpText(string s)
    {
        uiTextPowerUp.text = s;
    }
    public void PowerUpSpeedUp(float f)
    {
        _currentspeed = f;
    }

    public void ResetSpeed()
    {
        _currentspeed = speed;
    }

    public void PowerUpInvincibility(bool b = true)
    {
        Invicibility = b;
    }

    
    #endregion
}
