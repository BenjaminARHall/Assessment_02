using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {
    private float _timeRemaining;

    private float maxTime = 2 * 60; //in seconds

    private int maxHealth = 1;

    private bool isInvulnerable = false;

    private int totalRingsInLevel;

    private bool gameOver = false;

    private int _numRings;

    public int NumRings
    {
        get { return _numRings; }
        set { _numRings = value; }
    }

    private float _playerHealth;

    public float PlayerHealth
    {
        get { return _playerHealth; }
        set { _playerHealth = value; }
    }


    public float TimeRemaining
    {
        get { return _timeRemaining; }
        set { _timeRemaining = value; }

    }

    //private void OnEnable()
    //{
    //    DamagePlayerEvent.OnDamagePlayer += DecrementPlayerHealth;
    //}

    //private void OnDisable()
    //{
    //    DamagePlayerEvent.OnDamagePlayer -= DecrementPlayerHealth;
    //}
    // Use this for initialization
    void Start()
    {
        TimeRemaining = maxTime;
        PlayerHealth = maxHealth;

        totalRingsInLevel = GameObject.FindGameObjectsWithTag("Rings").Length;
    }
    void Update()
    {
        TimeRemaining -= Time.deltaTime;

        if (TimeRemaining <= 0)
        {
            Restart();
        }

        if (_numRings == totalRingsInLevel && !gameOver)
        {
            StartCoroutine(WonGame());
        }

    }

    private void DecrementPlayerHealth(GameObject player)
    {

        if (isInvulnerable)
        {
            return;
        }

        StartCoroutine(InvulnerableDelay());

        PlayerHealth--;

        if (PlayerHealth <= 0)
        {
            Restart();//Restart game
        }
    }

    public void Restart()
    {

        {
            Application.LoadLevel(Application.loadedLevel);
            TimeRemaining = maxTime;
            PlayerHealth = maxHealth;
            NumRings = 0;
        }
    }

    private IEnumerator InvulnerableDelay()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(1.0f);
        isInvulnerable = false;
    }

    public float GetPlayerHealthPercentage()
    {
        return PlayerHealth / (float)maxHealth;
    }

    private IEnumerator WonGame()
    {
        gameOver = true;
        FindObjectOfType<UpdateUI>().wonGamePanel.SetActive(true);
        yield return new WaitForSeconds(3);
        GameManager.Instance.Restart();
    }
}
