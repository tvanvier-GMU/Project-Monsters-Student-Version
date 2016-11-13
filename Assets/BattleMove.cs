using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BattleMove {
	
	public string attackName;
	public int baseDamage;
	public int baseAccuracy;
	public ElementType element;
	public TargetingType targetingType = TargetingType.SingleEnemy;

	public StatusEffect[] statusEffects;
	public BuffEffect[] buffEffects;
	public List<int> secondaryEffectChance;

	public override string ToString ()
	{
		string statusList = "";
		string buffList = "";
		if (statusEffects != null && statusEffects.Length > 0 ) {
			foreach (StatusEffect status in statusEffects) {
				statusList += (status.ToString ());
			}
		} else {
			statusList = "none";
		}

		if (buffEffects != null && buffEffects.Length > 0) {
			foreach (BuffEffect effect in buffEffects) {
				buffList += (effect.ToString ());
			}
		} else {
			buffList = "none";
		}

		return string.Format ("{0}\nBaseDamage: {1}\nBaseAccuracy: {2}\nElement: {3}\nStatusEffects: {4}\nSecondaryEffects: {5}", 
			attackName, baseDamage, baseAccuracy, element.ToString(), statusList, buffList);
	}

}
