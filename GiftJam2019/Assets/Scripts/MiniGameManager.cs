using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    bool running = false;
    Score score;

    public int ID;
    public float time;
    public Text score_display;
    public Text countdown;
    public float timeToEnd;
    public Image end;

    float timer;


    // float song_lenght;

    public bool IsRunning()
    {
        return running;
    }

    // Use this for initialization
    void Start()
    {
        // Score takes care of updating the display
        score = FindObjectOfType<Score>();
        score.display = score_display;

        StartCoroutine(CountDown());
        timer = 0;
    }

    // Must be called in update
    void CheckTimer()
    {
        if (running)
        {
            timer += Time.deltaTime;
            if(timer <= time)
            {
                running = false;
                StartCoroutine(End());
            }
        }
    }

    public void AddPoints(int amount)
    {
        int points = score.GetScore(ID);
        score.SetScore(ID, points + amount);
    }


    private IEnumerator CountDown()
    {
        for (int i = 3; i > 0; i--)
        {
            countdown.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        running = true;
    }

    private IEnumerator End()
    {
        end.enabled = true;
        yield return new WaitForSeconds(timeToEnd);
        end.enabled = false;
        SceneManager.LoadScene("Menu");
    }

}
