using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaquetePhysics : MonoBehaviour
{
    [Range(1, 10)]
    public float velocidade;

    GameManager gm;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();

    }

    // Update is called once per frame

void Update()
{
    if (gm.gameState == GameManager.GameState.MENU)
        transform.position = new Vector3(0, -4, 0); 
    if (gm.gameState != GameManager.GameState.GAME) return;
    
    float inputX = Input.GetAxis("Horizontal");
    transform.position += new Vector3(inputX, 0, 0) * Time.deltaTime * velocidade;  
    
    if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME) {
        gm.ChangeState(GameManager.GameState.PAUSE);
        }
    }
   void OnTriggerEnter2D(Collider2D col)
   {
       if (col.gameObject.tag == "LeftWall"){
           transform.position =  col.transform.position + new Vector3(4,0,0);
       }
       if (col.gameObject.tag == "RightWall"){
           transform.position =  col.transform.position + new Vector3(-4,0,0);
       }

       
   }
}
