using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuInit : MonoBehaviour
{
    public Text main_display;
    public Text[] displays;
    // Start is called before the first frame update
    void Start()
    {
        var score = FindObjectOfType<Score>() as Score;
        score.current_scene = SCENES.MENU;
        score.display = main_display;
        for(int i = 0; i < displays.Length; i++) {
            displays[i].text = score.GetScore(i).ToString("0000");
        }
    }

}
