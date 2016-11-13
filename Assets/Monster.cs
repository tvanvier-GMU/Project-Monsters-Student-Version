using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public abstract class Monster : MonoBehaviour {

	public string nickname;
	public abstract string speciesName{ get; }
	public abstract ElementType primaryType{ get; }
	public abstract ElementType secondaryType { get; }
	[Range(0, 100)]
	public int level;
	[Range(0, 999)]
	public int currentHealth;
	public StatusType statusAffliction = StatusType.None;

	[System.Serializable]
	public struct Stats{
		public int health;
		public int attack;
		public int defense;
		public int specialAttack;
		public int specialDefense;
		public int speed;
		public int accuracy;
		public int evasion;
		public Stats(int Health, int Attack, int Defense, int SpecialAttack, int SpecialDefense, int Speed, int Accuracy, int Evasion){
			health = Health; attack = Attack; defense = Defense; specialAttack = SpecialAttack;
			specialDefense = SpecialDefense; speed = Speed; accuracy = Accuracy; evasion = Evasion;
		}
	}

	public abstract Stats baseStats{ get; }

	public Stats levelGainedStats;
	public Stats battleStatModifier;

	public BattleMove[] moves = new BattleMove[4];

	public int maxHealth {
		get {
			return baseStats.health + levelGainedStats.health + battleStatModifier.health;
		}
	}

	[Header("(For Display Only)")]
	public string[] READONLY_moves = new string[4];

	// Use this for initialization
	void Awake () {
		currentHealth = baseStats.health + levelGainedStats.health;
		AddTestMove ();
	}

	// Update is called once per frame
	void Update () {
		UpdateMovesInEditor ();
		if (currentHealth < 0) {
			currentHealth = 0;
		}
	}

	protected virtual void AddTestMove(){
		Debug.Log ("Don't add moves while using the base class lol");
	}

	protected void UpdateMovesInEditor(){
		for (int i = 0; i < moves.Length; i++) {
			if (moves [i] != null) {
				READONLY_moves [i] = moves [i].ToString();
			}
		}
	}
}
