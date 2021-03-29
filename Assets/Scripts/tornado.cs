using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tornado : MonoBehaviour
{
    public TornadoControl score;

    public GameObject tornadoo;
    public float pullSpeed;


    // three trigger zone for the tornado
    private bool trigger0 = false;
    private bool trigger = false;
    private bool trigger2 = false;


    private void Start()
    {
        GetComponent<Rigidbody>().Sleep();
    }

    void Update()
    {
        // out layer of the tornado *20 multiplier
        if (trigger0 == true)
        {
            GetComponent<Rigidbody>().AddForce((tornadoo.transform.position - transform.position) * 20 * Time.smoothDeltaTime);
            trigger2 = true;
        }

        // mid layer of the tornado *pullspeed multiplier ( you can set on the editor )
        if (trigger == true)
        {
            GetComponent<Rigidbody>().AddForce((tornadoo.transform.position - transform.position) * pullSpeed * Time.smoothDeltaTime);
            trigger2 = true;

        }

        // this line for the optimization if tornado touches the object that activates the rigidbody but in here we looking if do not touches
        // so rigidbody stays sleep for optimization
        if(trigger2 == false)
        {
            GetComponent<Rigidbody>().Sleep();

        }


    }

    private void OnTriggerEnter(Collider other)
    {
        // controls the out layer of tornado
        if (other.gameObject.CompareTag("far") && other.isTrigger)
        {
            trigger0 = true;

        }

        // controls the mid layer of tornado
        if (other.gameObject.CompareTag("alan") && other.isTrigger)
        {
            trigger = true;

        }

        // if object touches the center of tornado it will be destroyed in 0.5 seconds
        if (other.gameObject.CompareTag("merkez") && other.isTrigger)
        {
            StartCoroutine(destroy());


        }

    }

    private void OnTriggerExit(Collider other)
    {
        // this line controls the object is in the tornado's area or not
        if (other.gameObject.CompareTag("alan") && other.isTrigger)
        {
            trigger = false;
        }

    }

    // this line destroys the object if it's center of the tornado
    IEnumerator destroy()
    {

        yield return new WaitForSeconds(.5f);
        gameObject.SetActive(false);
        Destroy(gameObject);
        score.scoreUp();
    }

}
