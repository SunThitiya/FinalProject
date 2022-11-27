using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool open;
    public bool enter;
    public bool audios;
    public AudioClip openAudio;
    public AudioClip closeAudio;
    public float smooth = 2.0f;
    public float dooropenAngle = -90.0f;
    private Vector3 defaultRot;
    private Vector3 openRot;
    // Start is called before the first frame update
    void Start()
    {
        defaultRot = transform.eulerAngles;
        openRot = new Vector3(defaultRot.x, defaultRot.y + dooropenAngle, defaultRot.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && enter)
        {
            open = !open;
        }
        if (open)
        {
            if(audios == false)
            {
                  GetComponent<AudioSource>().PlayOneShot(openAudio);
                  audios = true;
            }
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
            
        }
        else
        {
            if(audios == true)
             {
                GetComponent<AudioSource>().PlayOneShot(closeAudio);
                audios = false;
            }
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);
        }
           
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enter = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enter = false;
        }
    }
}
