using UnityEngine;
using UnityEngine.InputSystem;

public class Hazscript : MonoBehaviour
{ 
     
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    public int TeleportEvery = 0;   // frames between teleports (~2 seconds at 60 fps)
    int counter =0;  // initialize counter to 0

    void Update()
    { 
        counter++;                    // count up every frame

        if (counter >= TeleportEvery)
        {
            counter = 0;              // reset the count

            Vector3 where = new Vector3();
            where.x = Random.Range(-8f, 8f);
            where.y = Random.Range(-5f, 5f);
            transform.position = where;   // wall jumps somewhere new
        }
    }
}
    
   

   
