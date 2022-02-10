using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class splashListener : MonoBehaviour, IActionListener
{
    [SerializeField] private GameObject pf_beginButton;
    [SerializeField] private Transform transform_canvas;
    private GameObject lv_beginButton;

    // Start is called before the first frame update
    void Start()
    {
        lv_beginButton = Instantiate<GameObject>(pf_beginButton, transform_canvas);
        lv_beginButton.TryGetComponent<buttonAction>(out buttonAction out_buttonAction);
        lv_beginButton.TryGetComponent<RectTransform>(out RectTransform out_rectTransform);
        out_rectTransform.anchoredPosition = new Vector3(0f, 135f, 0f);
        out_buttonAction.lv_listener = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void listen(string in_action)
    {
        switch (in_action)
        {
            case "Begin":
                SceneManager.LoadScene("Loading");
                break;
        }
    }
}
