using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UFOInfoHolder : MonoBehaviour
{
    [SerializeField] private Text date;
    [SerializeField] private Text time;
    [SerializeField] private Text city;
    [SerializeField] private Text state;
    [SerializeField] private Text country;
    [SerializeField] private Text shape;
    [SerializeField] private Text duration;
    [SerializeField] private Text latitude;
    [SerializeField] private Text longitude;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectUFO(UFOSighting in_ufo)
    {
        date.text = $"Date: {in_ufo.Date}";
        time.text = $"Time: {in_ufo.Time}";
        city.text = $"City: {in_ufo.City}";
        state.text = $"State: {in_ufo.State}";
        country.text = $"Country: {in_ufo.Country}";
        shape.text = $"Shape: {in_ufo.Shape}";
        duration.text = $"Duration: {in_ufo.Duration}";
        latitude.text = $"Latitude: {in_ufo.Latitude}";
        longitude.text = $"Longitude: {in_ufo.Longitude}";
    }
}
