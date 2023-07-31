using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuUIHelper : MonoBehaviour
{
    public TextMeshProUGUI gameovertext;
    public TMP_InputField nameField;
    public GameObject startGame;
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.IsGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ( GameManager.Instance.IsGameOver) gameOver();

        if ( GameManager.Instance.IsGameOver && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
       
    }

    public void onStartButton()
    {
        GameManager.Instance.PlayerName = nameField.text;
        startGame.gameObject.SetActive(false);
        SceneManager.LoadScene("Game", LoadSceneMode.Single);

    }
    private void gameOver()
    {
        gameovertext.gameObject.SetActive(true);
    }

}
