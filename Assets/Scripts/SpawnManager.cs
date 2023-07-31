using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public List<GameObject> Enemy = new List<GameObject>();
    
    public GameObject Item;
    public GameObject Goal;
    public GameObject Block;
    private float limitEspace = 20f;
    private int numberOfBlock = 50;
    // Start is called before the first frame update
    void Awake()
    {
        SpawnEnemy(3);
        SpawnBlock(numberOfBlock);
        SpawnItem();
        SpawnGoal();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private Vector3 GeneratePos()
    {
        Vector3 pos = new Vector3(  x:Random.Range(-limitEspace,limitEspace) ,
                                    y:0.1f ,
                                    z:Random.Range(-limitEspace,limitEspace) );
        return pos;
    }

    private Vector3 GenerateScale()
    {
        Vector3 scale = new Vector3(    x: Random.Range(1,3),
                                        y: Random.Range(1,3),
                                        z: Random.Range(1,3));
        return scale;
    }

    public void SpawnEnemy(int number)
    {
        for ( int i = 0 ; i < number; i++)
        {
            Instantiate(Enemy[Random.Range(0,Enemy.Count)], GeneratePos(), Quaternion.identity );
        }
    }

    public void SpawnItem()
    {
        Vector3 temp = new Vector3();
        temp = GeneratePos();
        temp.y += 0.65f;
        Instantiate(Item, temp, Item.transform.rotation);
    }

    public void SpawnGoal()
    {
        
        Instantiate(Goal, GeneratePos(), Quaternion.identity);
        
    }

    public void SpawnBlock(int number)
    {
        for(int i = 0 ; i < number; i++)
        {
            Instantiate(Block, GeneratePos(), Quaternion.identity);
            Block.transform.localScale = GenerateScale();
        }
    }
}
