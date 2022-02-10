using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UFOShipNavigator : MonoBehaviour
{
    private int ufo_index;
    private GameObject currentUFO;
    [SerializeField] Dropdown dropDown_state;
    [SerializeField] Dropdown dropDown_city;
    [SerializeField] UFOInfoHolder ufoInfo;

    // Start is called before the first frame update
    void Start()
    {

        UFOData.filter_list_UFO = new List<UFOSighting>(UFOData.list_of_sightings);

        dropDown_city.gameObject.SetActive(false);
        ufo_index = 0;
        loadUFO();
        dropDown_state.onValueChanged.AddListener(delegate {
            stateDropDownChange(dropDown_state);
        });
        dropDown_city.onValueChanged.AddListener(delegate {
            cityDropDownChange(dropDown_city);
        });

        filterStateUpdate();
        filterCityUpdate();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void stateDropDownChange(Dropdown in_drop){
        UFOData.filter_list_UFO.Clear();
        UFOData.cities.Clear();
        UFOData.shapes.Clear();

        if (in_drop.value == 0)
        {
            UFOData.filter_list_UFO = new List<UFOSighting>(UFOData.list_of_sightings);
        } else
        {
            foreach (UFOSighting it_UFO in UFOData.list_of_sightings)
            {
                if (it_UFO.State.Equals(in_drop.options[in_drop.value].text))
                {
                    UFOData.filter_list_UFO.Add(it_UFO);
                    UFOData.cities.Add(it_UFO.City);
                    UFOData.shapes.Add(it_UFO.Shape);
                }
            }
        }

        if (UFOData.cities.Count > 0)
            dropDown_city.gameObject.SetActive(true);
        else
            dropDown_city.gameObject.SetActive(false);

        ufo_index = 0;
        loadUFO();
        filterCityUpdate();
    }
    private void cityDropDownChange(Dropdown in_drop)
    {
        UFOData.filter_list_UFO.Clear();
        UFOData.shapes.Clear();

        if (in_drop.value == 0)
        {
            stateDropDownChange(dropDown_state);
        } else
        {
            foreach (UFOSighting it_UFO in UFOData.list_of_sightings)
            {
                if (it_UFO.City.Equals(in_drop.options[in_drop.value].text) && it_UFO.State.Equals(dropDown_state.options[dropDown_state.value].text))
                {
                    UFOData.filter_list_UFO.Add(it_UFO);
                    UFOData.shapes.Add(it_UFO.Shape);
                }
            }

            ufo_index = 0;
            loadUFO();
        }

    }

    public void filterStateUpdate()
    {
        UFOData.states = new HashSet<string>();
        foreach (UFOSighting it_UFO in UFOData.filter_list_UFO)
        {
            UFOData.states.Add(it_UFO.State);
        }
        UFOData.states.Add("");
        dropDown_state.ClearOptions();
        List<string> lv_states = new List<string>(UFOData.states);
        lv_states.Sort();
        dropDown_state.AddOptions(lv_states);
    }

    public void filterCityUpdate()
    {
        UFOData.cities = new HashSet<string>();
        foreach (UFOSighting it_UFO in UFOData.filter_list_UFO)
        {
            UFOData.cities.Add(it_UFO.City);
        }
        UFOData.cities.Add("");
        dropDown_city.ClearOptions();
        List<string> lv_cities = new List<string>(UFOData.cities);
        lv_cities.Sort();
        dropDown_city.AddOptions(lv_cities);
    }


    public void nextUFO()
    {
        ufo_index = (ufo_index + 1) % (UFOData.filter_list_UFO.Count);
        loadUFO();
    }

    public void previousUFO()
    {
        ufo_index = (ufo_index - 1 < 0) ? UFOData.filter_list_UFO.Count - 1 : ufo_index - 1;
        loadUFO();
    }

    public void loadUFO()
    {
        UFOSighting lv_ufo = UFOData.filter_list_UFO[ufo_index];
        if (currentUFO != null) currentUFO.transform.GetChild(0).GetComponent<shipPassive>().exit();
        currentUFO = Instantiate(Resources.Load<GameObject>($"Ships/{lv_ufo.Shape}"), new Vector3(-10f, 2.5f, 1f), Quaternion.identity);

        ufoInfo.selectUFO(lv_ufo);
    }
}
