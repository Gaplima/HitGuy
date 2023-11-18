using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MunicaoController : MonoBehaviour{
    public UnityEvent OnBalasChanged;
    public int Balas { get; private set; }
    public void AddBalas(int amount){
        Balas += amount;
        OnBalasChanged.Invoke();
    }
}
