using UnityEngine;

public class Wallscript : MonoBehaviour
{
    public int TeleportEvery = 180;   // frames between teleports (~3 seconds at 60 fps)
    int counter = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    // Update is called once per frame
   

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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerScript ps = other.gameObject.GetComponent<PlayerScript>();
            if (ps != null)
            {
                // Attempt to deduct a point from the player if possible
                // Use reflection so the wall can still penalize the player
                // without breaking compilation when that method is missing.
                var scoreMethod = ps.GetType().GetMethod("GetPoint");
                if (scoreMethod != null)
                {
                    scoreMethod.Invoke(ps, new object[] { -1 });
                }
            }

            // Teleport the player to center screen
            other.transform.position = new Vector3(0, 0, 0);
        }
    }
}