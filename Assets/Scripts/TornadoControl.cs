using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TornadoControl : MonoBehaviour
{
    public Slider slider;
    public GameObject completeCanvas;
    public GameObject fingerSlideImage;

    private Touch touch;
    private float touchSpeed;
    public int score = 0;

    void Start()
    {
        //Modifing the speed otherwise it can be too fast
        touchSpeed = 0.1f;
    }

    void Update()
    {
        Debug.Log(score);
        if (Input.touchCount > 0)
        {
            if (score == 0)
            {
              fingerSlideImage.gameObject.SetActive(true);
            }
            // if there is more than 1 finger this line set it to 1 finger
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.y * touchSpeed * -1,
                    transform.position.y,
                    transform.position.z + touch.deltaPosition.x * touchSpeed);
            }
        }
        
    }
    
    //this line controls the score. If all cubes destroyed complete canvas will be open
    public void scoreUp()
    {
        score++;
        slider.value = score;

        if(slider.value == slider.maxValue)
        {
            completeCanvas.gameObject.SetActive(true);
        }
    }

    // this method for the onClick event. Used on Start again button
    public void loadScene()
    {
        SceneManager.LoadScene(0);
    }
}
