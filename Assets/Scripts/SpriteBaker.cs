using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBaker : MonoBehaviour
{

    public Vector2Int   res = new Vector2Int(128, 128);
    public int          frameCount = 5;
    [Range(1, 32)]
    public int          snapsPerFrame = 1;
    public float        timeBetweenSnaps = 0.0f;
    public string       baseName = "test";
    public Animator     animator;

    RenderTexture   rtTarget;
    Texture2D       texture;
    Camera          mainCamera;
    bool            takeScreenshot;
    int             frameId;
    int             snapId;
    float           snapTimer;
    float           animTime;

    void Start()
    {
        mainCamera = GetComponent<Camera>();

        rtTarget = new RenderTexture(res.x, res.y, 32, UnityEngine.Experimental.Rendering.DefaultFormat.LDR);
        texture = new Texture2D(res.x * snapsPerFrame, res.y * frameCount, UnityEngine.Experimental.Rendering.DefaultFormat.LDR, UnityEngine.Experimental.Rendering.TextureCreationFlags.None);

        mainCamera.targetTexture = rtTarget;

        frameId = 0;
        snapId = 0;
        snapTimer = 0;

        if (animator)
        {
            animator.speed = 0.0f;
            animTime = 0;
        }
    }

    private void Update()
    {
        if (animator)
        {
            animator.Play(0, 0, (animTime < 1.0f)?(animTime):(0.99f));
        }
    }

    void OnPostRender()
    {
        snapTimer -= Time.deltaTime;
        
        if (snapTimer > 0) return;

        snapTimer = timeBetweenSnaps;

        if (mainCamera.targetTexture != null)
        {
            Debug.Log("Snap " + snapId + " of frame " + frameId + " // T= " + animTime);

            RenderTexture.active = rtTarget;

            texture.ReadPixels(new Rect(0, 0, res.x, res.y), snapId * res.x, (res.y * (frameCount - 1)) - frameId * res.y);
            texture.Apply();

            snapId++;
            if (snapId >= snapsPerFrame)
            {
                snapId = 0;
                frameId++;

                if (frameId >= frameCount)
                {
                    byte[] bytes = texture.EncodeToPNG();

                    System.IO.File.WriteAllBytes("Output/" + baseName + ".png", bytes);

                    mainCamera.targetTexture = null;

                    UnityEditor.EditorApplication.isPlaying = false;
                }
                else
                {
                    animTime = (float)frameId / (float)(frameCount - 1);
                }
            }
        }
    }    
}
