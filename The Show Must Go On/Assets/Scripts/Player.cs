using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject[] boxes = new GameObject[4];

    private KeyCode[] inputs = {KeyCode.RightArrow, KeyCode.RightArrow, 
                                KeyCode.DownArrow, KeyCode.LeftArrow};



    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        foreach(Transform child in transform)       // init children.
        {
            if (i >= 4) break;

            boxes[i] = child.gameObject;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
