using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject[] boxes = new GameObject[4];

    private KeyCode[] inputs = {KeyCode.RightArrow, KeyCode.UpArrow, 
                                KeyCode.DownArrow, KeyCode.LeftArrow};

    private Queue<Beats> beatsInput0 = new Queue<Beats> ();
    private Queue<Beats> beatsInput1 = new Queue<Beats> ();
    private Queue<Beats> beatsInput2 = new Queue<Beats> ();
    private Queue<Beats> beatsInput3 = new Queue<Beats> ();

    [SerializeField] // Debug line DELETE
    private static GameManager gameManager;

    private static MusicLanesTweener musicBoxAnimator;

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        musicBoxAnimator = FindObjectOfType<MusicLanesTweener>();

        int i = 0;
        foreach(Transform child in transform.GetChild(0))       // init children.
        {
            if (i >= 4) break;

            boxes[i] = child.gameObject;
            i++;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(inputs[0]) && beatsInput0.Count != 0)
        {

            int score = beatsInput0.Peek().CheckNote();
            if (score > 0)
            {
                gameManager.AddScore(score);
                Debug.Log("GOOOOD TIME"); // DELETE ME WHEN BUILDING
            }
            else
            {
                Debug.Log("YOUR BAD TIME"); // DELETE ME WHEN BUILDING
                SubtractScoreGM(-score);
            }
        }
        else if (Input.GetKeyDown(inputs[1]) && beatsInput1.Count != 0)
        {
            int score = beatsInput1.Peek().CheckNote();
            if (score > 0)
            {
                gameManager.AddScore(score);
                Debug.Log("GOOOOD TIME"); // DELETE ME WHEN BUILDING
            }
            else
            {
                Debug.Log("YOUR BAD TIME"); // DELETE ME WHEN BUILDING
                SubtractScoreGM(-score);
            }
        }
        else if (Input.GetKeyDown(inputs[2]) && beatsInput2.Count != 0)
        {
            int score = beatsInput2.Peek().CheckNote();
            if (score > 0)
            {
                Debug.Log("GOOOOD TIME"); // DELETE ME WHEN BUILDING
                gameManager.AddScore(score);
            }
            else
            {
                Debug.Log("YOUR BAD TIME"); // DELETE ME WHEN BUILDING
                SubtractScoreGM(-score);
            }
        }
        else if (Input.GetKeyDown(inputs[3]) && beatsInput3.Count != 0)
        {

            int score = beatsInput3.Peek().CheckNote();
            if (score > 0)
            {
                Debug.Log("GOOOOD TIME"); // DELETE ME WHEN BUILDING
                gameManager.AddScore(score);
            }
            else
            {
                Debug.Log("YOUR BAD TIME"); // DELETE ME WHEN BUILDING
                SubtractScoreGM(-score);
            }
        }

    }

    /// <summary>
    /// Adds beat to a input queue.
    /// </summary>
    /// <param name="input">The type of input that must be input.</param>
    /// <param name="beats">The beat.</param>
    /// 
    /// 2022-08-20 RB Initial documentation.
    /// 
    public void AddBeat(int input, Beats beats)
    {
        switch (input)
        {
            case 0:
                beatsInput0.Enqueue(beats);
                break;
            case 1:
                beatsInput1.Enqueue(beats);
                break;
            case 2:
                beatsInput2.Enqueue(beats);
                break;
            case 3:
                beatsInput3.Enqueue(beats);
                break;
        }
    }

    public void DequeueBeat(int key)
    {
        switch (key)
        {
            case 0:
                if (beatsInput0.Count == 0) return;
                beatsInput0.Dequeue();
                break;
            case 1:
                if (beatsInput1.Count == 0) return;
                beatsInput1.Dequeue();
                break;
            case 2:
                if (beatsInput2.Count == 0) return;
                beatsInput2.Dequeue();
                break;
            case 3:
                if (beatsInput3.Count == 0) return;
                beatsInput3.Dequeue();
                break;
        }
    }

    public void SubtractScoreGM(int value)
    {
        gameManager.SubtractScore(value);
    }

    public GameObject[] GetBoxes()
    {
        return boxes;
    }

    public KeyCode[] Inputs
    {
        get { return inputs; }
        set { inputs = value; }
    }

    public void AnimateMusicBoxes(int boxIndex)
    {
        switch (boxIndex)
        {
            case 0:
                musicBoxAnimator.AnimateLane1();
                break;
            case 1:
                musicBoxAnimator.AnimateLane2();
                break;
            case 2:
                musicBoxAnimator.AnimateLane3();
                break;
            case 3:
                musicBoxAnimator.AnimateLane4();
                break;
        }
    }
}
