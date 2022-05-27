using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Universe : MonoBehaviour
{
    public List<StarSystem> starSystems;
    public StarShip starShip;

    private void Update()
    {
        Renderer[] renderers;
        CircleCollider2D collider;

        foreach(StarSystem system in starSystems)
        {
            renderers = system.gameObject.GetComponentsInChildren<Renderer>();
            collider = system.gameObject.GetComponent<CircleCollider2D>();

            if (starShip.GetLocation() == system)
            {            
                for(int i=0; i<renderers.Length; i++)
                {
                    renderers[i].enabled = false;
                    collider.enabled = false;
                }
            }
            else
            {
                for (int i = 0; i < renderers.Length; i++)
                {
                    renderers[i].enabled = true;
                    collider.enabled = true;
                }
            }
        }
    }

}
