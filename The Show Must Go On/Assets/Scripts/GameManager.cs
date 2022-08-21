using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private Player player;
    private KeyCode[] playerInputs;

    [SerializeField]
    private GameObject[] beats;

    private int score = 420;
    [SerializeField]
    private GameObject loseObj;
    [SerializeField]
    private Text scoreText;
    //36.5f;
    private float songLength = 36.5f;
    private float nextSongEnd;
    private int nextDisableBlock;
    
    [SerializeField]
    private int bpm = 125;
    private float bps;

    private float nextSpawn;

    //public Vector3 lane1S, lane2S, lane3S, lane4S, lane5S, lane6S, lane7S, lane8S;

    private GameObject[] boxesGo = new GameObject[4];
    private Vector3[] boxes = new Vector3[4];
    // naming conventions: "boxVerticalLocation" + "boxHorizontalLocation" + "Beat approach direction" 
    private Vector2[] lanes = new Vector2[8];

    private float cameraBTop, cameraBBottom, cameraBRight, cameraBLeft;

    private List<KeyCode> inputKeys = new List<KeyCode> 
                            { KeyCode.LeftArrow, KeyCode.DownArrow, 
                              KeyCode.UpArrow, KeyCode.RightArrow,
                              KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, 
                              KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H, 
                              KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L,
                              KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P, 
                              KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T,
                              KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X,
                              KeyCode.Y, KeyCode.Z};

    private AudioManager audioManager;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerInputs = player.Inputs;
        audioManager = FindObjectOfType<AudioManager>();
        audioManager.StartMusic();

        boxesGo = player.GetBoxes();
        for (int i = 0; i < boxes.Length; i++)
        {
            boxes[i] = boxesGo[i].transform.position;
        }

        nextDisableBlock = boxesGo.Length - 1;

        Camera camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        cameraBTop = camera.orthographicSize;
        cameraBRight = cameraBTop * Screen.width / Screen.height;
        cameraBBottom = -cameraBTop;
        cameraBLeft = -cameraBRight;

        // Set spawn points
        lanes[0] = new Vector2(boxes[1].x, cameraBTop);
        lanes[1] = new Vector2(cameraBRight, boxes[1].y);
        
        lanes[2] = new Vector2(cameraBRight, boxes[2].y);
        lanes[3] = new Vector2(boxes[2].x, cameraBBottom);

        lanes[4] = new Vector2(boxes[3].x, cameraBBottom);
        lanes[5] = new Vector2(cameraBLeft, boxes[3].y);

        lanes[6] = new Vector2(cameraBLeft, boxes[0].y);
        lanes[7] = new Vector2(boxes[0].x, cameraBTop);

        // get song length
        
        bps = 1.0f/(bpm/60.0f);
        
        nextSpawn = 1/bps;

        nextSongEnd = songLength;
    }

    void FixedUpdate()
    {
        if(nextSpawn < Time.time )
        {
            nextSpawn = Time.time + bps;
            SpawnBeat();
        }

        if(nextDisableBlock > 0 && nextSongEnd < Time.time && nextDisableBlock > -1)
        {
            switch (nextDisableBlock)
            {
                case 3:
                    audioManager.SilenceShaker();
                    break;
                case 1:
                    audioManager.SilenceTuba();
                    break;
            }
            boxesGo[nextDisableBlock].SetActive(false);
            nextDisableBlock -= 2;
            nextSongEnd += Time.time + songLength;
        }

        if (score < -500) loseObj.SetActive(true);
        scoreText.text = "Score: " + score;
    }

    private void SpawnBeat()
    {
        int lane = Random.Range(0, lanes.Length);

        int speed = 5; // temporary must change.
        int keyAIndex = -1;
        int keyBIndex = -1;

        Vector3 keyA = Vector3.zero;
        Vector3 keyB = Vector3.zero;
        bool horizontalMovement = true;

        // can reduce to four lanes
        switch (lane)
        {
            // negative movement direction
            case 0:
                if (boxesGo[1].activeSelf)
                {
                    keyAIndex = 1;
                    keyA = boxes[keyAIndex];
                }

                if (boxesGo[2].activeSelf)
                {
                    keyBIndex = 2;
                    keyB = boxes[keyBIndex];
                }
                
                speed *= -1;
                horizontalMovement = false;
                break;
            case 1:
                if (boxesGo[1].activeSelf)
                {
                    keyAIndex = 1;
                    keyA = boxes[keyAIndex];
                }

                if (boxesGo[0].activeSelf)
                {
                    keyBIndex = 0;
                    keyB = boxes[keyBIndex];
                }
                
                speed *= -1;
                break;
            case 2:
                if (boxesGo[2].activeSelf)
                {
                    keyAIndex = 2;
                    keyA = boxes[keyAIndex];
                }

                if (boxesGo[3].activeSelf)
                {
                    keyBIndex = 3;
                    keyB = boxes[keyBIndex];
                }
                
                speed *= -1;
                break;
            case 7:
                if (boxesGo[0].activeSelf)
                {
                    keyAIndex = 0;
                    keyA = boxes[keyAIndex];
                }

                if (boxesGo[3].activeSelf)
                {
                    keyBIndex = 3;
                    keyB = boxes[keyBIndex];
                }

                speed *= -1;
                horizontalMovement = false;
                break;
            
                // positive movement direction
            case 3:
                if (boxesGo[2].activeSelf)
                {
                    keyAIndex = 2;
                    keyA = boxes[keyAIndex];
                }

                if (boxesGo[1].activeSelf)
                {
                    keyBIndex = 1;
                    keyB = boxes[keyBIndex];
                }
                
                horizontalMovement = false;
                break;
            case 4:
                if (boxesGo[3].activeSelf)
                {
                    keyAIndex = 3;
                    keyA = boxes[keyAIndex];
                }

                if (boxesGo[0].activeSelf)
                {
                    keyBIndex = 0;
                    keyB = boxes[keyBIndex];
                }
                
                horizontalMovement = false;
                break;
            case 5:
                if (boxesGo[3].activeSelf)
                {
                    keyAIndex = 3;
                    keyA = boxes[keyAIndex];
                }

                if (boxesGo[2].activeSelf)
                {
                    keyBIndex = 2;
                    keyB = boxes[keyBIndex];
                }
                    
                break;
            case 6:
                if (boxesGo[0].activeSelf)
                {
                    keyAIndex = 0;
                    keyA = boxes[keyAIndex];
                }

                if (boxesGo[1].activeSelf)
                {
                    keyBIndex = 1;
                    keyB = boxes[keyBIndex];
                }
                
                break;
        }

        int keyType = Random.Range(0, playerInputs.Length);
        GameObject gO = Instantiate(beats[keyType]);
        gO.transform.position = lanes[lane];

        Beats beat = gO.GetComponent<Beats>();
        beat.Initialize(player, keyType, speed, 0.2f, lanes[lane], keyA, keyB, keyAIndex, keyBIndex, horizontalMovement);

        player.AddBeat(keyType, beat);
    }

    public void AddScore(int value)
    {
        score += value;
    }

    public void SubtractScore(int value)
    {
        score -= value;
    }

    public void MissedInstrument(int value)
    {
        switch (value)
        {
            case 0:
                audioManager.MisfirePercussion();
                break;
            case 1:
                audioManager.MisfireTuba();
                break;
            case 2:
                audioManager.MisfireShaker();
                break;
            case 3:
                audioManager.MisfirePercussion();
                break;
        }
    }
}
