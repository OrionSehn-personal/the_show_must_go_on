using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beats : MonoBehaviour
{
    public float start;
    public float goodtime1;
    public float goodtime2;
    public float speed;
    public float tolerance;
    public Vector3 spawnerLocation;
    private KeyCode correctInput;

    public Beats(
        KeyCode correctInput,
        int speed,
        float tolerance,
        Vector3 spawnerLocation,
        Vector3 inputKeyA,
        Vector3 inputKeyB)
    // Creates a beat object, takes the location of the spawner, and the two instruments along the lane which it will pass.
    {

        this.start = Time.time;
        this.speed = speed;
        this.goodtime1 = this.start + ((inputKeyA - spawnerLocation)/speed)
        this.goodtime2 = this.start + ((inputKeyB - spawnerLocation)/speed)

        this.correctInput = correctInput;
        this.tolerance = tolerance;

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
