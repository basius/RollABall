using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorEsfera : MonoBehaviour {
    public float speed;
    public int count;
    public Text text;
    public Text winText;
    void Start()
    {
        count = 0;
        text.text = "Puntos: 0";
        winText.text = "";
        updateCounter();
    }
	// Update is called once per frame
	void FixedUpdate () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);

        GetComponent<Rigidbody>().AddForce(direction * speed);
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "pickUp")
        {
            Destroy(other.gameObject);
            count++;
            text.text = "Puntos: " + count;
            updateCounter();
        }
    }

    void updateCounter()
    {
        int numPickups = GameObject.FindGameObjectsWithTag("pickUp").Length;
        text.text = "Puntos: " + count;
       
        if(numPickups == 1)
        {
            winText.text = "Has ganado!";
        }
    }
}
