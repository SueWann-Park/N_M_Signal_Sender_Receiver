using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    SignalSender sender;

    // Start is called before the first frame update
    void Start()
    {
        sender = GameObject.Find("Sender").GetComponent<SignalSender>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O) == true)
        {
            sender.SendOn();
        }
        if(Input.GetKeyDown(KeyCode.C) == true)
        {
            sender.SendOff();
        }
    }
}
