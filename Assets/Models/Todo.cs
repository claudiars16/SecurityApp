using System;
using UnityEngine;
namespace Models
{
	[Serializable]
	public class Todos
	{
		public int id;

		public int userId;

		public string title;

		public bool completed;

		public override string ToString(){
			return UnityEngine.JsonUtility.ToJson (this, true);
		}
	}
}

