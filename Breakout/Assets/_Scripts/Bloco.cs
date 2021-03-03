using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour
{

    private int durabilidade;
    private SpriteRenderer sprite;
    private bool unbreakable;
    private GameManager gm;



    // Start is called before the first frame update
    void Start()
    {

        gm = GameManager.GetInstance();

        unbreakable = false;
        durabilidade = Random.Range(1,5);
        sprite = gameObject.GetComponent<SpriteRenderer>();
        if (durabilidade == 4){
            unbreakable = true;
            sprite.color = Color.black;
        }
        
        else if (durabilidade == 3)
            sprite.color = Color.magenta;
        else if (durabilidade == 2)
            sprite.color = Color.yellow;
        else
            sprite.color = Color.white;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!unbreakable)
            durabilidade--;
        
        if (durabilidade == 0){
            gm.pontos++;
            Destroy(gameObject);}

        
        else if (durabilidade == 3)
            sprite.color = Color.magenta;
        else if (durabilidade == 2)
            sprite.color = Color.yellow;
        else if (durabilidade == 1)
            sprite.color = Color.white;
    }
}
