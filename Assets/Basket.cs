using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    public Text scoreGT;

    // Start is called before the first frame update
    void Start()
    {
        //Find a reference to the score counter game object
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;
        // The camera's z position sets how far to push the mouse in 3D
        mousePos2D.z = -Camera.main.transform.position.z;
        // Convert the point from 2D screen space into #D game world space.
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        // Move the X position of this basket to the x position of the mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //find out what hit this basket
        GameObject collidedWith = collision.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);
        }
        //parse the text of the score gt into an int
        int score = int.Parse(scoreGT.text);
        //add points
        score += 100;
        scoreGT.text = score.ToString();

        if (score > HighScore.score)
        {
            HighScore.score = score;
        }
    }
}
