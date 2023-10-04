using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Coin : MonoBehaviour{
    public int Score;
    public TMP_Text coinText;
    void Start(){

    }
    void Update(){
        coinText.text = "Score: " + Score.ToString();
    }
}
