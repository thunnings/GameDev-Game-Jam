using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI locationLabel;
    public TextMeshProUGUI dateLabel;
    public StarShip starShip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        locationLabel.text = starShip.GetLocation().systemName;
        dateLabel.text = starShip.GetDate().ToString() + " After Earth";
    }
}
