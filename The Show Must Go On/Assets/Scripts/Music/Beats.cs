using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beats : MonoBehaviour
{
    private int speed;

    private KeyCode correctInput;

    public Beats(KeyCode correctInput, int speed)
    {
        this.correctInput = correctInput;
        this.speed = speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
