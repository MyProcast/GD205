using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Transform playerTransform;

    public Transform hazard; 
    public Transform[] hazards; 

    Vector3 initPos;

    public AudioClip deathClip;
    AudioSource speaker;

    public Transform block;

    Vector3 newPosition;

    public Transform fieldParent;

    public Vector3 fwd, bwd, lft, rgt, up, dwn;

    void Start()
    {
        initPos = playerTransform.position;
        speaker = GetComponent<AudioSource>();
    }

    void Update()
    {
        controls();

        updatePosition();
        checkHazards();
    }


    public void controls()
    {

        newPosition = playerTransform.position;

        if (Input.GetKeyDown(KeyCode.W))
        {
            newPosition = playerTransform.position + fwd;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            newPosition = playerTransform.position + bwd;

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            newPosition += lft;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            newPosition += rgt;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            newPosition += dwn;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            newPosition += up;
        }

    }

    public void updatePosition()
    {
        if (newPosition.y <= 4.75 && newPosition.y >= 1 
          && newPosition.x >= 1 && newPosition.x <= 7.25
          && newPosition.z >= 1 && newPosition.z <= 7.25)
        {

            if (newPosition != block.position)
            {
                playerTransform.position = newPosition;
            }
        }
    }

    public void checkHazards()
    {
        for (int i = 0; i < hazards.Length; i++)
        { 
            if (playerTransform.position == hazards[i].position)
            { 
                playerTransform.position = initPos; 
                speaker.PlayOneShot(deathClip, 0.6f);
            }
        }

        if (playerTransform.position == hazard.position)
        {
            playerTransform.position = initPos; 
            speaker.PlayOneShot(deathClip, 0.6f);
        }

    }
}

