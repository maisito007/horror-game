using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTriggerObject : MonoBehaviour
{
    public Light redRoomLight1, whiteHallWayLight1;
    public HornZombieController zomControl1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LightsOn()
    {
        redRoomLight1.enabled = true;
        whiteHallWayLight1.enabled = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ZombieEvent1")
        {
            LightsOn();
            zomControl1.MoveZombie();

        }
    }
}
