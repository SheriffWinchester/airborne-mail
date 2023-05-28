using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDrop : MonoBehaviour
{
    public GameObject airDrop;
    Vector2 airdropForce;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAirdrop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnAirdrop()
    {
        while(true)
        {
            airDrop = Instantiate(airDrop, new Vector3(12.0f, 3.0f, 0.0f), Quaternion.identity);
            //airDrop.GetComponent<Rigidbody2D>().AddForce(new Vector2(-5.0f, 0.0f));

            yield return new WaitForSeconds(5.0f);
        }
    }
}
