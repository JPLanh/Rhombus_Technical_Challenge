using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonAction : MonoBehaviour
{

    public IActionListener lv_listener { get; set; }
    [SerializeField] private string lv_action;
    [SerializeField] private Text lv_name;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick()
    {
        lv_listener.listen(lv_action);
    }

    public void init(IActionListener in_listener, string in_action, string in_name)
    {
        lv_listener = in_listener;
        lv_action = in_action;
        lv_name.text = in_name;
    }
}
