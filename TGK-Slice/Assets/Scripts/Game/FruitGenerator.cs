using UnityEngine;
using System.Collections;

public class FruitGenerator : MonoBehaviour {

	public GameObject fruit;
	public GameObject bomb;
	public GameObject heart;

	public float cooldownTime;
	private float cooldownCount;

	public bool enableTossStyle1;
	private int fruitTossStyle1Wave;
	private int fruitTossStyle1WaveCount;
	private int fruitTossStyle1Number;
	
	public bool enableTossStyle2;
	private int fruitTossStyle2Wave;
	private int fruitTossStyle2WaveCount;
	private int fruitTossStyle2Count;
	private int fruitTossStyle2Number;
	private float fruitTossStyle2CooldownCount;
	private float fruitTossStyle2CooldownTime;
	private bool isToss2;

	private int bombCount;
	private int bombNumber;

	private float heartCount;
	private float heartTime;

	// Use this for initialization
	void Start () {
		GameState.state = 1;

		cooldownCount = cooldownTime;

		fruitTossStyle1Wave = 3;
		fruitTossStyle1WaveCount = 1;
		fruitTossStyle1Number = 3;

		fruitTossStyle2Wave = 5;
		fruitTossStyle2WaveCount = 1;
		fruitTossStyle2CooldownTime = 0.5f;
		fruitTossStyle2Number = 3;
		isToss2 = false;

		bombCount=0;
		bombNumber=Random.Range(3,7);

		heartTime = Random.Range(15,30);
		heartCount = heartTime;
	}
	
	// Update is called once per frame
	void Update () {
		if(GameState.state==1){
			generateFruit();
			generateHeart();
		}
	}

	void generateFruit(){
		cooldownCount -= Time.deltaTime;
		if(cooldownCount<=0){
			if(fruitTossStyle1Wave==fruitTossStyle1WaveCount&&enableTossStyle1){
				for(int i=0;i<fruitTossStyle1Number;i++)
					instantiateTarget();

				fruitTossStyle1WaveCount=0;
				fruitTossStyle1Wave++;
				fruitTossStyle1Number++;
				if(fruitTossStyle1Wave>5)
					fruitTossStyle1Wave=3;
				if(fruitTossStyle1Number>6)
					fruitTossStyle1Number=3;
			}
			else if(fruitTossStyle2Wave==fruitTossStyle2WaveCount&&enableTossStyle2){
				fruitTossStyle2Count = 0;
				fruitTossStyle2CooldownCount = fruitTossStyle2CooldownTime;
				isToss2=true;

				fruitTossStyle2WaveCount=0;
				fruitTossStyle2Wave++;
				if(fruitTossStyle2Wave>6)
					fruitTossStyle2Wave=5;
			}
			else
				instantiateTarget();
			
			
			cooldownCount=cooldownTime;
			fruitTossStyle1WaveCount++;
			fruitTossStyle2WaveCount++;
		}

		if(isToss2){
			if(fruitTossStyle2CooldownCount<=0){
				instantiateTarget();
				fruitTossStyle2CooldownCount = fruitTossStyle2CooldownTime;
				fruitTossStyle2Count++;
				if(fruitTossStyle2Count==fruitTossStyle2Number){
					isToss2=false;
					fruitTossStyle2Number++;
					if(fruitTossStyle2Number>6)
						fruitTossStyle2Number=3;
				}
			}
			fruitTossStyle2CooldownCount -= Time.deltaTime;
		}
	}

	void generateHeart(){
		heartCount -= Time.deltaTime;
		if(heartCount<=0){
			Instantiate(heart);
			heartTime = Random.Range(15,30);
			heartCount = heartTime;
		}
	}

	void instantiateTarget(){
		if(bombCount!=bombNumber){
			Instantiate(fruit);
			bombCount++;
		}
		else{
			Instantiate(bomb);
			bombCount=0;
			bombNumber=Random.Range(3,7);
		}
	}
}
