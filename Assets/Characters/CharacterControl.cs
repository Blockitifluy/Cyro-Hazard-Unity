using System.Collections.Generic;
using UnityEngine;
using CH.Items.Container;

namespace CH.Character
{
	[RequireComponent(typeof(MovementBasics))]
	[RequireComponent(typeof(CharacterHealth))]
	public abstract class CharacterControl : MonoBehaviour
	{
		[HideInInspector]
		public MovementBasics MovementBasics;
		[HideInInspector]
		public CharacterHealth CharacterHealth;

		public List<Backpack> DetectBackpacks()
		{
			var allBackpacks = GameObject.FindGameObjectsWithTag("Backpack");
			List<Backpack> actualPacks = new();

			foreach (GameObject obj in allBackpacks)
			{
				if (gameObject.transform.IsChildOf(obj.transform)) continue;

				if (!obj.TryGetComponent<Backpack>(out var backpack))
				{
					Debug.LogWarning($"Even though {obj.name} has tag backpack, it's doesn't have the Backpack component");
					continue;
				}

				actualPacks.Add(backpack);
			}

			return actualPacks;
		}

		public virtual void Awake()
		{
			MovementBasics = GetComponent<MovementBasics>();
			CharacterHealth = GetComponent<CharacterHealth>();
		}
	}
}