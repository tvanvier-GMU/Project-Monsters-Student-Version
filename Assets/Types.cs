using UnityEngine;
using System.Collections;

public enum ElementType {
	None,
	Normal,
	Fire,
	Water,
	Grass
}

public enum StatusType {
	None,
	Paralyze,
	Sleep,
	Burn,
	Freeze
}

public enum BuffType{
	attackUp,
	defenseUp,
	specialAttackUp,
	specialDefenseUp,
	speedUp,
	accuracyUp,
	evasionUp,
	attackDown,
	defenseDown,
	specialAttackDown,
	specialDefenseDown,
	speedDown,
	accuracyDown,
	evasionDown
}

public enum TargetingType{
	SingleEnemy,
	Self,
	AllEnemies,
	All
}

public struct StatusEffect {
	public StatusType status;
	public int chance;
	public TargetingType target;

	public override string ToString ()
	{
		return string.Format ("{0}({1}%) ", status.ToString(), chance.ToString());
	}
	public StatusEffect(StatusType Status, int Chance, TargetingType hitTarget){
		status = Status;
		chance = Chance;
		target = hitTarget;
	}
}

public struct BuffEffect {
	public BuffType effect;
	public int chance;
	public int magnitude;
	public TargetingType target;
	public override string ToString ()
	{
		return string.Format ("{0}({1}%) ", effect.ToString(), chance.ToString());
	}
	public BuffEffect(BuffType Effect, int Chance, int Magnitude, TargetingType hitTarget){
		effect = Effect;
		chance = Chance;
		magnitude = Magnitude;
		target = hitTarget;
	}
}