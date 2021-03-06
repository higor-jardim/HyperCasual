using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;
using DG.Tweening;

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
    public GameObject winScreen;
    public AudioSource audioSource;

    [Header("Text")]
    public TextMeshPro uiTextPowerUp;

    [Header("Coin Setup")]
    public GameObject coinCollector;

    [Header("Animation")]
    public AnimatorManager animatorManager;

    [Header("VFX & Sounds")]
    public ParticleSystem vfxDeath;
    public AudioSource soundDeath;

    [Header("Limits")]
    public Vector2 limitVector = new Vector2(-4, 5);

    [SerializeField] private BounceHelper _bounceHelper;

    public bool Invicibility = true;

    //privates
    private bool _canrun;
    private Vector3 _pos;
    private float _currentSpeed;
    private Vector3 _startPosition;
    private float _baseSpeedAnimation = 7f;

    private void Start()
    {
        _startPosition = transform.position;
        ResetSpeed();
        _bounceHelper.SpawnBounce();
    }

    public void Bounce()
    {
        if(_bounceHelper != null)
        _bounceHelper.Bounce();
    }

    void Update()
    {
       if (!_canrun) return;


       _pos = target.position;
       _pos.y = transform.position.y;
       _pos.z = transform.position.z;

        if (_pos.x < limitVector.x) _pos.x = limitVector.x;
        else if (_pos.x > limitVector.y) _pos.x = limitVector.y;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime); 
       transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagToCheckEnemy)
        {
           if(Invicibility == false)
            {
                EndGame(AnimatorManager.AnimationType.DEAD);
            }
        }

        if (collision.transform.tag == tagToCheckFinishLine)
        {
            
            WinLevel();
            
        }
    }

    private void EndGame(AnimatorManager.AnimationType animationType = AnimatorManager.AnimationType.IDLE)
    {
        _canrun = false;
        endScreen.SetActive(true);
        animatorManager.Play(animationType);
        if (vfxDeath != null) vfxDeath.Play();
        if (soundDeath != null) soundDeath.Play();
    }

    private void WinLevel(AnimatorManager.AnimationType animationType = AnimatorManager.AnimationType.IDLE)
    {
        _canrun = false;
        audioSource.Stop();
        winScreen.SetActive(true);
        animatorManager.Play(animationType);
        transform.position = _startPosition;
        LevelManager.Instance.CreateLevelPieces();
    }

    public void StartToRun()
    {
        _canrun = true;
        animatorManager.Play(AnimatorManager.AnimationType.RUN, _currentSpeed / _baseSpeedAnimation);
        audioSource.Play();
    }


    #region POWER UPS

    public void SetPowerUpText(string s)
    {
        uiTextPowerUp.text = s;
    }
    public void PowerUpSpeedUp(float f)
    {
        Bounce();
        _currentSpeed = f;
    }

    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }

    public void PowerUpInvincibility(bool b = true)
    {
        Bounce();
        Invicibility = b;
    }

    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease)
    {
        Bounce();
        transform.DOMoveY(_startPosition.y + amount, animationDuration).SetEase(ease);
        Invoke(nameof(ResetHeight), duration);
    }

    public void ResetHeight()
    {
        transform.DOMoveY(_startPosition.y, .1f);
    }

    public void ChangeCoinCollectorSize(float amount)
    {
        coinCollector.transform.localScale = Vector3.one * amount;
    }

    #endregion
}
