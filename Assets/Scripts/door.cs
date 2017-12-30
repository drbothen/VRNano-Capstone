using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class door : MonoBehaviour
{

    public float smooth = 2.0f;
    public float DoorOpenAngle = 90.0f;
    public float CompleteAngle = 89.9f;
    public GameObject Doorobj;
    public string TargetScene;

    private bool open = false;

    private Quaternion defaultRot;
    private Quaternion openRot;

	// Use this for initialization
	void Start ()
    {
        defaultRot = Doorobj.transform.rotation;
        openRot = defaultRot * Quaternion.Euler(0, DoorOpenAngle, 0);
    }
	
	// Update is called once per frame
	void Update () {
	    if (open)
	    {
            Doorobj.transform.rotation = Quaternion.Slerp(transform.rotation, openRot, Time.deltaTime * smooth);
	        if (Quaternion.Angle(defaultRot, Doorobj.transform.rotation) > CompleteAngle)
	        {
                SceneManager.LoadScene(TargetScene);
            }
        }
		
	}

    public void openDoor ()
    {
        if (!open)
        {
            Doorobj.GetComponent<AudioSource>().Play();
            open = true;
        }
    }
}
