using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuUIHelper : MonoBehaviour
{
    public TextMeshProUGUI gameovertext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( GameManager.Instance.IsGameOver) gameOver();
       
    }

    private void gameOver()
    {
        gameovertext.gameObject.SetActive(true);
    }

}
