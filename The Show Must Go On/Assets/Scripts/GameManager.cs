using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private Player player;
    private KeyCode[] playerInputs;

    [SerializeField]
    private GameObject[] beats;

    private int score = 420;

    private float songLength = 60;
    [SerializeField]
    private int bpm = 60;
    private int bps;

    private float nextSpawn;

    //public Vector3 lane1S, lane2S, lane3S, lane4S, lane5S, lane6S, lane7S, lane8S;
    
    private Vector3[] boxes = new Vector3[4];
    // naming conventions: "boxVerticalLocation" + "boxHorizontalLocation" + "Beat approach direction" 
    private Vector2[] lanes = new Vector2[8];

    private float cameraBTop, cameraBBottom, cameraBRight, cameraBLeft;

    private List<KeyCode> inputKeys = new List<KeyCode> 
                            { KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, 
                              KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H, 
                              KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L,
                              KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P, 
                              KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T,
                              KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X,
                              KeyCode.Y, KeyCode.Z, KeyCode.LeftArrow,
                              KeyCode.DownArrow, KeyCode.UpArrow, KeyCode.RightArrow};

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerInputs = player.Inputs;

        GameObject[] boxes = player.GetBoxes();
        for (int i = 0; i < boxes.Length; i++)
        {
            this.boxes[i] = boxes[i].transform.position;
        }

        Camera camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        cameraBTop = camera.orthographicSize;
        cameraBRight = cameraBTop * Screen.width / Screen.height;
        cameraBBottom = -cameraBTop;
        cameraBLeft = -cameraBRight;

        // Set spawn points
        lanes[0] = new Vector2(boxes[1].transform.position.x, cameraBTop);
        lanes[1] = new Vector2(cameraBRight, boxes[1].transform.position.y);
        
        lanes[2] = new Vector2(cameraBRight, boxes[2].transform.position.y);
        lanes[3] = new Vector2(boxes[2].transform.position.x, cameraBBottom);

        lanes[4] = new Vector2(boxes[3].transform.position.x, cameraBBottom);
        lanes[5] = new Vector2(cameraBLeft, boxes[3].transform.position.y);

        lanes[6] = new Vector2(cameraBLeft, boxes[0].transform.position.y);
        lanes[7] = new Vector2(boxes[0].transform.position.x, cameraBTop);

        // get song length
        bps = bpm/60;
        nextSpawn = bps;

    }

    void Update()
    {
        if(nextSpawn < Time.time )
        {
            nextSpawn = Time.time + bps;
            SpawnBeat();
        }
    }

    private void SpawnBeat()
    {
        int lane = Random.Range(0, lanes.Length);
        int speed = 5; // temporary must change.
        //float speed = 
        Vector3 keyA = Vector3.zero;
        Vector3 keyB = Vector3.zero;
        bool horizontalMovement = true;
        // can reduce to four lanes
        switch (lane)
        {
            case 0:
                keyA = boxes[1];
                keyB = boxes[2];
                speed *= -1;
                horizontalMovement = false;
                break;
            case 1:
                keyA = boxes[1];
                keyB = boxes[0];
                speed *= -1;
                break;
            case 2:
                keyA = boxes[2];
                keyB = boxes[3];
                speed *= -1;
                break;
            case 7:
                keyA = boxes[0];
                keyB = boxes[3];
                speed *= -1;
                horizontalMovement = false;
                break;
            
            case 3:
                keyA = boxes[2];
                keyB = boxes[1];
                horizontalMovement = false;
                break;
            case 4:
                keyA = boxes[3];
                keyB = boxes[0];
                horizontalMovement = false;
                break;
            case 5:
                keyA = boxes[3];
                keyB = boxes[2];
                break;
            case 6:
                keyA = boxes[0];
                keyB = boxes[1];
                break;
                
        }

        int keyType = Random.Range(0, playerInputs.Length);
        GameObject gO = Instantiate(beats[keyType]);
        gO.transform.position = lanes[lane];

        Beats beat = gO.GetComponent<Beats>();
        beat.Initialize(playerInputs[keyType], speed, 0.5f, lanes[lane], keyA, keyB, horizontalMovement);
    }

}
