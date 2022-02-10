using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System.Threading;
using UnityEngine.SceneManagement;

public class UFOData : MonoBehaviour
{
    public static List<UFOSighting> list_of_sightings;
    public static HashSet<string> states;
    public static HashSet<string> shapes;
    public static HashSet<string> cities;

    string result;
    public static List<UFOSighting> filter_list_UFO;

    // Start is called before the first frame update
    void Start()
    {
        //        StartCoroutine(loadUFO("", "UFO Sightings.json"));
        StartCoroutine(loadStreamingAsset("UFO Sightings.json"));
        states = new HashSet<string>();
        shapes = new HashSet<string>();
        cities = new HashSet<string>();
    }
    IEnumerator loadStreamingAsset(string fileName)
    {
        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, fileName);

        if (filePath.Contains("://") || filePath.Contains(":///"))
        {
            WWW www = new WWW(filePath);
            yield return www;
            result = www.text;
        }
        else
        {
            result = System.IO.File.ReadAllText(filePath);
        }

        list_of_sightings = JsonConvert.DeserializeObject<List<UFOSighting>>(result);
        SceneManager.LoadScene("mainScene");
    }

    IEnumerator loadUFO(string in_path, string in_file)
    {
		bool done = false;
		new Thread(() => {
            string lv_data = File.ReadAllText($"{in_path}{in_file}");
            list_of_sightings = JsonConvert.DeserializeObject<List<UFOSighting>>(lv_data);
			done = true;
		}).Start();

		while (!done)
		{
			yield return null;
		}
        SceneManager.LoadScene("mainScene");
    }
}
