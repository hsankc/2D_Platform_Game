using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuMenagerMenuScene : MonoBehaviour
{
    public GameObject DataBoard;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void DataBoardButton()
    {
        DataMenager.Instance.LoadData();

        DataBoard.transform.GetChild(1).GetComponent<Text>().text = DataMenager.Instance.totalShotBullet.ToString();
        DataBoard.transform.GetChild(2).GetComponent<Text>().text = DataMenager.Instance.totalEnemyKilled.ToString();
        DataBoard.SetActive(true);
    }


    public void XButton()
    {
        DataBoard.SetActive(false);
    }

}
