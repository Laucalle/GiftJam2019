using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    bool running = false;
    protected Score score;

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
    void Awake()
    {
        // Score takes care of updating the display
        score = FindObjectOfType<Score>();
        score.display = score_display;

        StartCoroutine(CountDown());
        timer = 0;
    }

    // Must be called in update
    protected void CheckTimer()
    {
        if (running)
        {
            timer += Time.deltaTime;
            if(timer >= time)
            {
                running = false;
                StartCoroutine(End());
            }
        }
    }

    public void AddPoints(int amount)
    {
        if (running)
        {
            int points = score.GetScore(ID);
            score.SetScore(ID, points + amount);
        }
    }


    private IEnumerator CountDown()
    {
        for (int i = 3; i > 0; i--)
        {
            countdown.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        running = true;
        countdown.gameObject.SetActive(false);
    }

    private IEnumerator End()
    {
        end.gameObject.SetActive(true);
        yield return new WaitForSeconds(timeToEnd);

        end.gameObject.SetActive(false);
        SceneManager.LoadScene("Menu");
    }

}
