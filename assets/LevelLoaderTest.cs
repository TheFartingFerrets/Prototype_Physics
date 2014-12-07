using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelLoaderTest : MonoBehaviour {

	public struct LevelData
	{
		public Vector2 Roller;
		public Vector2 Target;
		public Vector2[] Bonus;

	}

	public LevelData levelData = new LevelData();

	public GameObject Roller;
	public GameObject Target;
	public List<GameObject> Bonus = new List<GameObject>();


	void Awake()
	{

	}

	void Start()
	{
		levelData.Roller = new Vector2 (-1, -1);
		levelData.Target = new Vector2 (3,3);
		levelData.Bonus = new Vector2[5];
		levelData.Bonus [0] = new Vector2 (1, 1);
		levelData.Bonus [1] = new Vector2 (1, 2);
		levelData.Bonus [2] = new Vector2 (1, 3);
		levelData.Bonus [3] = new Vector2 (1, 4);
		levelData.Bonus [4] = new Vector2 (1, 5);	
		LoadLevel ();
	}


	void LoadLevel()
	{
		StartLevel (levelData);
	}



	void StartLevel( LevelData data )
	{
		SpawnRoller(data.Roller);
		SpawnTarget(data.Target);
		SpawnBonus (data.Bonus);
	}



	void SpawnRoller( Vector2 position )
	{
		Roller = (GameObject)Instantiate (Resources.Load ("Roller"), position, Quaternion.identity);
	}
	void SpawnTarget( Vector2 position )
	{
		Target = (GameObject)Instantiate( Resources.Load("s_Target"), position, Quaternion.identity);
	}
	void SpawnBonus( Vector2[] positions )
	{
		for (int i = 0; i < positions.Length; i++) 
		{
			GameObject b = (GameObject)Instantiate(Resources.Load("s_Bonus"), positions[i], Quaternion.identity);
			Bonus.Add( b );
		}
	}



}
