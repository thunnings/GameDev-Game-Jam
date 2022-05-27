using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Universe : MonoBehaviour
{
    public List<StarSystem> starSystems;
    public StarShip starShip;

    public void UpdateUniverse()
    {
        Renderer[] renderers;
        CircleCollider2D collider;
        SpriteRenderer spriteRenderer;

        foreach(StarSystem system in starSystems)
        {
            renderers = system.gameObject.GetComponentsInChildren<Renderer>();
            spriteRenderer = system.gameObject.GetComponentInChildren<SpriteRenderer>();
            collider = system.gameObject.GetComponent<CircleCollider2D>();

            if (starShip.GetLocation() == system)
            {            
                for(int i=0; i<renderers.Length; i++)
                {
                    spriteRenderer.color = Color.red;
                    collider.enabled = false;
                }
            }
            else
            {
                for (int i = 0; i < renderers.Length; i++)
                {
                    spriteRenderer.color = Color.white;
                    renderers[i].enabled = true;
                    collider.enabled = true;
                }
            }
        }
    }

}
