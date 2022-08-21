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
    private int keyAIndex;
    private int keyBIndex;
    private int correctInput;
    private bool keyCorrect = false;
    private Player player;

    private bool destroyed = false;
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

    private void FixedUpdate()
    {
        if (horizontalMovement)
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        else
            transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    // Creates a beat object, takes the location of the spawner, and the two instruments along the lane which it will pass.
    public void Initialize(Player player, int correctInput, int speed, float tolerance,
        Vector3 spawnerLocation, Vector3 inputKeyA, Vector3 inputKeyB, int keyAIndex, int keyBIndex, bool horizontalMovement)
    {
        this.player = player;
        this.startTime = Time.time;
        this.speed = speed;

        this.keyAIndex = keyAIndex; 
        this.keyBIndex = keyBIndex;
        if(keyAIndex != -1)
            this.goodTime1 = Mathf.Abs((Vector3.Distance(inputKeyA, spawnerLocation) / speed));
        if(keyBIndex != -1)
            this.goodTime2 = Mathf.Abs((Vector3.Distance(inputKeyB, spawnerLocation) / speed));

        //this.goodTime1 = this.start + ((inputKeyA - spawnerLocation) / speed);
        //this.goodTime2 = this.start + ((inputKeyB - spawnerLocation) / speed);

        this.correctInput = correctInput;
        this.tolerance = tolerance;
        this.horizontalMovement = horizontalMovement;

        Destroy(gameObject, goodTime2 > 0 ? goodTime2 : goodTime1);
    }

    private void OnDestroy()
    {
        destroyed = true;
        if (!keyCorrect)
        {
            player.DequeueBeat(correctInput);
            player.SubtractScoreGM(20);
        }
    }

    public int CheckNote()
    {
        if (destroyed)
            return 0;
        keyCorrect = true;
        if(keyAIndex != -1 && Time.time < goodTime1 + tolerance + startTime && 
            Time.time > goodTime1 - tolerance + startTime)
        {
            player.AnimateMusicBoxes(keyAIndex);
            player.DequeueBeat(correctInput);
            return 20;
        }
        else if (keyAIndex != -1 && Time.time < goodTime2 + tolerance + startTime && 
            Time.time > goodTime2 - tolerance + startTime)
        {
            player.AnimateMusicBoxes(keyBIndex);
            player.DequeueBeat(correctInput);
            return 10;
        }
        player.DequeueBeat(correctInput);
        gameObject.SetActive(false);
        return -20;
    }
}
