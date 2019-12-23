using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SCENES
{
    ANTONIO,
    CRIS,
    GERMAN,
    JAVI,
    MENU
}

public class Score : MonoBehaviour
{
    public static Score SC;
    private int[] scores = new int[(int)SCENES.MENU];
    int total;
    public Text display;
    public SCENES current_scene;
    // Start is called before the first frame update
    void Awake()
    {
        if(SC != null)
        {
            GameObject.Destroy(this);
        } else
        {
            SC = this;
            DontDestroyOnLoad(this);
        }
        
    }

    public int GetScore(int idx)
    {
        return scores[idx];
    }
    public void SetScore(int idx, int amount)
    {
        total -= scores[idx];
        scores[idx] = amount;
        total += scores[idx];

    }

    private void Update()
    {
        switch(current_scene){
            case SCENES.MENU:
                display.text = total.ToString("0000");
                break;
            default:
                display.text = scores[(int)current_scene].ToString("0000");
                break;
        }

    }

}
