using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject[] cubes;
    public int Score;
    public Text Score_Tex;
    public AudioSource bubble;
  
    void Update()
    {
        Score_Tex.text = Score.ToString();
    }
}
