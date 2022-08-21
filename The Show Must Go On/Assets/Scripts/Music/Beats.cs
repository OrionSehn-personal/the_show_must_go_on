using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beats : MonoBehaviour
{
    private bool horizontalMovement = true;
    public float startTime;
    public float goodTime1;
    public float goodTime2;
    public float speed;
    public float tolerance;
    public Vector3 spawnerLocation;
    private int correctInput;

    private Player player;
    // Creates a beat object, takes the location of the spawner, and the two instruments along the lane which it will pass.
    //public Beats(KeyCode correctInput, int speed, float tolerance,
    //    Vector3 spawnerLocation, Vector3 inputKeyA, Vector3 inputKeyB, bool horizontalMovement)
    //{

    //    this.start = Time.time;
    //    this.speed = speed;
    //    //this.goodTime1 = this.start + ((inputKeyA - spawnerLocation) / speed);
    //    //this.goodTime2 = this.start + ((inputKeyB - spawnerLocation) / speed);

    //    this.correctInput = correctInput;
    //    this.tolerance = tolerance;
    //    this.horizontalMovement = horizontalMovement;
    //}

    // Start is called before the first frame update
    void Start()
    {
    
        

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        if (horizontalMovement)
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        else
            transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    // Creates a beat object, takes the location of the spawner, and the two instruments along the lane which it will pass.
    public void Initialize(Player player, int correctInput, int speed, float tolerance,
        Vector3 spawnerLocation, Vector3 inputKeyA, Vector3 inputKeyB, bool horizontalMovement)
    {
        this.player = player;
        this.startTime = Time.time;
        this.speed = speed;
        this.goodTime1 = Mathf.Abs((Vector3.Distance(inputKeyA, spawnerLocation) / speed));
        this.goodTime2 = Mathf.Abs((Vector3.Distance(inputKeyB, spawnerLocation) / speed));
        //this.goodTime1 = this.start + ((inputKeyA - spawnerLocation) / speed);
        //this.goodTime2 = this.start + ((inputKeyB - spawnerLocation) / speed);

        this.correctInput = correctInput;
        this.tolerance = tolerance;
        this.horizontalMovement = horizontalMovement;

        Destroy(gameObject, goodTime2);
    }

    private void OnDestroy()
    {
        player.DequeueBeat(correctInput);
    }

    public int CheckNote()
    {
        Debug.Log("Good time 1 = " + goodTime1 + startTime);
        Debug.Log("Good time 2 = " + goodTime2 + startTime);
        if(Time.time < goodTime1 + tolerance + startTime && Time.time > goodTime1 - tolerance + startTime)
        {
            Destroy(gameObject);
            return 20;
        }
        else if (Time.time < goodTime2 + tolerance + startTime && Time.time > goodTime2 - tolerance + startTime)
        {
            Destroy(gameObject);
            return 10;
        }
        Destroy(gameObject);
        return -20;
    }

    //void CheckNote(float curTime, KeyCode key)
    //{

    //    if (key == correctInput)
    //    {
    //        if (Mathf.Abs(curTime - this.goodTime1))
    //        {
    //            Debug.Log("correct inside box1");
    //        }

    //        if (Mathf.Abs(curTime - this.goodTime2))
    //        {
    //            Debug.Log("correct inside box2");
    //        }
    //    }

    //    if (Mathf.Abs(curTime - this.goodTime1))
    //    {
    //        Debug.Log("inside box1");
    //    }

    //    if (Mathf.Abs(curTime - this.goodTime2))
    //    {
    //        Debug.Log("inside box2");
    //    }


    //}

}
