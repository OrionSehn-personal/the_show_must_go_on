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

    // Start is called before the first frame update
    void Awake()
    {
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
            // if good time.
            // else good time.
            if (beatsInput0.Peek().CheckNote())
            {
                Debug.Log("GOOOOD TIME");
            }
            else
            {
                Debug.Log("YOUR BAD TIME");
            }
        }
        else if (Input.GetKeyDown(inputs[1]) && beatsInput1.Count != 0)
        {
            // if good time.
            // else good time.
            if (beatsInput1.Peek().CheckNote())
            {
                Debug.Log("GOOOOD TIME");
            }
            else
            {
                Debug.Log("YOUR BAD TIME");
            }
        }
        else if (Input.GetKeyDown(inputs[2]) && beatsInput2.Count != 0)
        {
            // if good time.
            // else good time.
            if (beatsInput2.Peek().CheckNote()){
                Debug.Log("GOOOOD TIME");
            }
            else
            {
                Debug.Log("YOUR BAD TIME");
            }
        }
        else if (Input.GetKeyDown(inputs[3]) && beatsInput3.Count != 0)
        {
            // if good time.
            // else good time.
            if (beatsInput3.Peek().CheckNote())
            {
                Debug.Log("GOOOOD TIME");
            }
            else
            {
                Debug.Log("YOUR BAD TIME");
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

    public GameObject[] GetBoxes()
    {
        return boxes;
    }

    public KeyCode[] Inputs
    {
        get { return inputs; }
        set { inputs = value; }
    }
}
