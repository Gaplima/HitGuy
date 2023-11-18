using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Municao : MonoBehaviour{
    public int Score;
    public TMP_Text municaoText;
    void Start(){
        Score = 10;
    }
    void Update(){
        municaoText.text = "Municao: " + Score.ToString();
    }
}