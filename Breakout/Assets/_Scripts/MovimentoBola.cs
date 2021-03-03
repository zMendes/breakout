using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBola : MonoBehaviour
{
    [Range(1, 15)]
    public float velocidade = 5.0f;
    
    GameManager gm;

    private Vector3 direcao;

    private bool start;

    // Start is called before the first frame update
    void Start()
    {
        float dirX = Random.Range(-5.0f, 5.0f);
        float dirY = Random.Range(1.0f, 5.0f);
        direcao = new Vector3(dirX, dirY).normalized;
        start = false;

        gm = GameManager.GetInstance();

        
    }
    

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space) && gm.gameState == GameManager.GameState.GAME)
            start = true;

        if (gm.gameState == GameManager.GameState.MENU) {
            transform.position = GameObject.FindGameObjectWithTag("Raquete").transform.position + new Vector3(0,0.4f,0);
        }
        
        if (gm.gameState != GameManager.GameState.GAME) return;
        
        if (start)
            transform.position += direcao * Time.deltaTime * velocidade;
        else 
            transform.position = GameObject.FindGameObjectWithTag("Raquete").transform.position + new Vector3(0,0.4f,0);
    

        //Debug.Log($"Vidas: {gm.vidas} \t | \t Pontos: {gm.pontos}");


    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "LeftWall" || col.gameObject.tag == "RightWall")
            direcao = new Vector3(-direcao.x, direcao.y);
        if (col.gameObject.tag == "TopWall")
            direcao = new Vector3(direcao.x, -direcao.y);
        if (col.gameObject.tag == "DownWall")
           Reset();
        if (col.gameObject.tag == "Tijolo"){
            SoundManager.Play("block");
            direcao = new Vector3(direcao.x, -direcao.y);
        }

        if (col.gameObject.tag == "LeftSide"){
                float dirX = Random.Range(-5.0f, -1.0f);
                float dirY = Random.Range(1.0f, 5.0f);
                direcao = new Vector3(dirX, dirY).normalized;
        }
        if (col.gameObject.tag == "Center"){
                float dirY = Random.Range(1.0f, 5.0f);
                direcao = new Vector3(0, dirY).normalized;
        }
        if (col.gameObject.tag == "RightSide"){
                float dirX = Random.Range(1.0f, 5.0f);
                float dirY = Random.Range(1.0f, 5.0f);

                direcao = new Vector3(dirX, dirY).normalized;
        }
    }

    private void Reset()
   {
       Vector3 playerPosition = GameObject.FindGameObjectWithTag("Raquete").transform.position;
       transform.position = playerPosition;

       direcao = new Vector3(0, 1);
       gm.vidas--;
       start = false;       
       if(gm.vidas <= 0 && gm.gameState == GameManager.GameState.GAME)
        {
            SoundManager.Play("over");
            gm.ChangeState(GameManager.GameState.ENDGAME);

        } 
   }

}
