using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

    public Color max;
    public float min = .2f;
    public bool isFading = true;

    public float incrementAmount = .05f;

    public float currentAlpha = 0;

    private Color current;

    public float frequencyInSeconds = .1f;
    public float timeSinceLastUpdate = 0;

    private Renderer renderer;
    private MaterialPropertyBlock propertyBlock;

    private void Awake()
    {
        current = max;
        propertyBlock = new MaterialPropertyBlock();
        renderer = GetComponent<Renderer>();

}


public void Update()
    {
        timeSinceLastUpdate += Time.deltaTime;
        if (frequencyInSeconds < timeSinceLastUpdate)
        {

            if (isFading)
            {
                current.a -= incrementAmount;

                if (current.a <= min)
                {
                    isFading = false;
                }
            }
            else
            {
                current.a += incrementAmount;

                if (current.a >= max.a)
                {
                    isFading = true;
                }
            }

            currentAlpha = current.a;

            renderer.GetPropertyBlock(propertyBlock);
            propertyBlock.SetColor("_Color", current);
            renderer.SetPropertyBlock(propertyBlock);

            timeSinceLastUpdate -= frequencyInSeconds;
        }
    }
}
