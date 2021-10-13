using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornZombieController : MonoBehaviour
{
    public Transform moveTo;
    public Animator thisAnim;
    public float speed, speedLookAt;
    // Start is called before the first frame update
    void Start()
    {
        thisAnim.SetBool("Idle", true);
        thisAnim.SetBool("Run", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(MoveZombieToPos(moveTo.position));
           
        }
    }
    public void MoveZombie()
    {
        StartCoroutine(MoveZombieToPos(moveTo.position));
    }
    IEnumerator MoveZombieToPos(Vector3 moveToPos)
    {
         thisAnim.SetBool("Idle", false);
        thisAnim.SetBool("Run", true);
        while(this.transform.position != moveToPos)
        //this.transform.position.x < baitPos.x -1f
        {
           
            Debug.Log("Moving");
            this.transform.position = Vector3.MoveTowards(this.transform.position, moveToPos, Time.deltaTime * speed);

            // Instant LookAt()
            // Vector3 baitLookAtPos = new Vector3(baitPos.x,this.transform.position.y, baitPos.z);
            // this.transform.LookAt(baitLookAtPos);
            var rotation = Quaternion.LookRotation(moveToPos - this.transform.position);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, Time.deltaTime * speedLookAt);

            // Vector3 eulerRotation = new Vector3(Camera.main.transform.eulerAngles.x, this.transform.eulerAngles.y, Camera.main.transform.eulerAngles.z);
            // Camera.main.transform.rotation = Quaternion.Euler(eulerRotation);


            yield return null;
        }
    }
}
