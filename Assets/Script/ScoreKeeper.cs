using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] int currentScore;
    static ScoreKeeper instance;

    //Goi ManageSingleton trong Awake de quan ly instance
    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetCurrentScore()
    {
        return this.currentScore;
    }

    public void ResetScore()
    {
        this.currentScore = 0;
    }

    public void ModifyScore(int score)
    {
        this.currentScore += score;
    }
}
