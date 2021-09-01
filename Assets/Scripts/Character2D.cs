using System;
using UnityEngine;

public class Character2D : MonoBehaviour
{
    [Serializable]
    public struct Clip
    {
        public string name;
        public Vector2 startPosition;   // UV space
        public Vector2 size;            // UV space
        public int frameCount;
    }

    public Clip[] clips;
    public float speed = 4f; // 4 frames per second

    public Clip currentClip;
    public int currentClipID;
    public float frameNumber = 0;
    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        currentClipID = clips.Length - 1;
        currentClip = clips[currentClipID];
    }

    // Update is called once per frame
    void Update()
    {        
        bool idle = false;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(Mathf.Abs(horizontal) < 0.1f && Mathf.Abs(vertical) < 0.1f)
        {
            idle = true;
        }

        else if(Mathf.Abs(horizontal) > Mathf.Abs(vertical))
        {
            if (horizontal > 0)
                currentClipID = 7;
            else
                currentClipID = 5;
        }
        else
        {
            if (vertical > 0)
                currentClipID = 6;
            else
                currentClipID = 4;
        }

        currentClip = clips[currentClipID - (idle ? 4 : 0)];

        frameNumber = (frameNumber + Time.deltaTime * speed) % currentClip.frameCount;
        material.mainTextureScale = currentClip.size;
        material.mainTextureOffset = currentClip.startPosition +
            new Vector2((int)frameNumber * currentClip.size.x, 0);
    }
}
