using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour
{

    private int durabilidade;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {

        durabilidade = Random.Range(1,4);
        sprite = gameObject.GetComponent<SpriteRenderer>();
        if (durabilidade == 3)
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
        durabilidade--;
        if (durabilidade == 0) Destroy(gameObject);

        
        if (durabilidade == 3)
            sprite.color = Color.magenta;
        else if (durabilidade == 2)
            sprite.color = Color.yellow;
        else
            sprite.color = Color.white;
    }
}
