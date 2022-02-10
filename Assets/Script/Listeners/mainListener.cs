using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainListener : MonoBehaviour, IActionListener
{
    [SerializeField] private UFOShipNavigator lv_ufo_navigator;
    [SerializeField] private Transform buttonList;

    // Start is called before the first frame update
    void Start()
    {
        createNewButton(out RectTransform out_next_rect, out buttonAction out_next_buttonAction);
        out_next_rect.anchoredPosition = new Vector3(0f, -5f, 0f);
        out_next_buttonAction.init(this, "Next", "Next");

        createNewButton(out RectTransform out_prev_rect, out buttonAction out_prev_buttonAction);
        out_prev_rect.anchoredPosition = new Vector3(0f, -35f, 0f);
        out_prev_buttonAction.init(this, "Previous", "Previous");


        createNewButton(out RectTransform out_exit_rect, out buttonAction out_exit_buttonAction);
        out_exit_rect.anchoredPosition = new Vector3(250f, -5f, 0f);
        out_exit_buttonAction.init(this, "Exit", "Exit");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void listen(string in_string)
    {
        switch (in_string)
        {
            case "Next":
                lv_ufo_navigator.nextUFO();
                break;
            case "Previous":
                lv_ufo_navigator.previousUFO();
                break;
            case "Exit":
                Application.Quit();
                break;
        }
    }


    private void createNewButton(out RectTransform out_rect, out buttonAction out_buttonAction){
        GameObject tmp_Button = Instantiate(Resources.Load<GameObject>("Action Button"), buttonList);
        tmp_Button.TryGetComponent<RectTransform>(out out_rect);
        tmp_Button.TryGetComponent<buttonAction>(out out_buttonAction);
    }
}
