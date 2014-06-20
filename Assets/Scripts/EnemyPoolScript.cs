using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPoolScript : MonoBehaviour 
{
	List<GameObject> EnemyList = new List<GameObject>();
	// Use this for initialization
	void Start () 
	{
	
	}

	private uint counter = 0;
	// Update is called once per frame
	void Update () 
	{
		if (counter % 100 == 0) 
		{
			if (EnemyList.Count < 10) 
			{
				GameObject enemy = (GameObject)Instantiate(Resources.Load("Enemy"));
				EnemyList.Add(enemy);
			}
           else
			{
				foreach(var enemy in EnemyList)
				{
					if (!enemy.activeInHierarchy)
					{
						enemy.SetActive(true);
						break;
					}

				}
			}
		}
		counter++;
	}
}
