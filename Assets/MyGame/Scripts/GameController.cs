using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    private TimeCount timeCount;
     public  Button button;
    public GameObject bu;



    void Start() {
        timeCount = GetComponent<TimeCount>();//获取TimeCount
        //button.enabled = false;
        bu.GetComponent<CanvasGroup>().alpha = 0;
        bu.GetComponent<CanvasGroup>().interactable = false;
        bu.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    void OnTriggerEnter(Collider other) {
        if (other.transform.root.tag == "Car") {
            timeCount.Stop();//计时停止
            bu.GetComponent<CanvasGroup>().alpha = 1;
            bu.GetComponent<CanvasGroup>().interactable = true;
            bu.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }
    public void onClick0()
    {
        SceneManager.LoadScene(2);
    }
    public void onClick1()
    {
        SceneManager.LoadScene(1);
    }
    public void onClick1_1()
    {
        SceneManager.LoadScene(5);
    }
    public void onClick1_2()
    {
        SceneManager.LoadScene(6);
    }
    public void onClick1_3()
    {
        SceneManager.LoadScene(7);
    }
    public void onClick2_1()
    {
        SceneManager.LoadScene(8);
    }
    public void onClick2_2()
    {
        SceneManager.LoadScene(9);
    }
    public void onClick2_3()
    {
        SceneManager.LoadScene(10);
    }
    public void onClick3_1()
    {
        SceneManager.LoadScene(11);
    }
    public void onClick3_2()
    {
        SceneManager.LoadScene(12);
    }
    public void onClick3_3()
    {
        SceneManager.LoadScene(13);
    }
    public void onClickback()
    {
        SceneManager.LoadScene(1);
    }
}
