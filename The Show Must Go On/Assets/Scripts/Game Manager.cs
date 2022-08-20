using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    int score = 420;

    public Vector3 lane1S, lane2S, lane3S, lane4S, lane5S, lane6S, lane7S, lane8S;

    private List<KeyCode> inputKeys = new List<KeyCode> 
                            { KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, 
                              KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H, 
                              KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L,
                              KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P, 
                              KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T,
                              KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X,
                              KeyCode.Y, KeyCode.Z, KeyCode.LeftArrow,
                              KeyCode.DownArrow, KeyCode.UpArrow, KeyCode.RightArrow};

    public Queue<Beats> beats;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
