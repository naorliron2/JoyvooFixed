using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class IngameUiManager : MonoSingleton<IngameUiManager>
{   
    [Header("Variables")]
    [SerializeField] float popupTime;
    [Header("References")]
    [SerializeField] GameObject popupBox;
    [SerializeField] TMP_Text popupBoxText;
    [SerializeField] GameObject endScreenPanel;
    [SerializeField] TMP_Text endScreenText;
    float timer;
    bool active;
    /// <summary>
    /// Pops up a message
    /// </summary>
    /// <param name="text"></param>
    public void PopUp(string text)
    {
        //start the timer
        active = true;
        //activate the popup and set the text
        popupBox.SetActive(true);
        popupBoxText.text = text;
        //reset timer
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
        TImerLogic();
    }
    public void ResetScene()
    {
        endScreenPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    /// <summary>
    /// Opens the lose panel and update the text
    /// </summary>
    /// <param name="message"></param>
    public void OpenLossScreen(string message)
    {
        endScreenPanel.SetActive(true);
        endScreenText.text = message;

    }
    private void TImerLogic()
    {
        
        if (active)
        {

            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                //When the timer end, deactivate the popup
                popupBox.SetActive(false);
                active = false;
            }
        }
    }
}
