using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IngameUiManager : MonoSingleton<IngameUiManager>
{
    [SerializeField] GameObject popupBox;
    [SerializeField] TMP_Text popupBoxText;
    [SerializeField] float popupTime;
    float timer;
    bool active;
    public void PopUp(string text)
    {

        active = true;
        popupBox.SetActive(true);
        popupBoxText.text = text;
        timer = popupTime;
    }
    // Start is called before the first frame update
    void Start()
    {
        popupBoxText = popupBox.GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                popupBox.SetActive(false);
                active = false;
            }
        }
    }
}
