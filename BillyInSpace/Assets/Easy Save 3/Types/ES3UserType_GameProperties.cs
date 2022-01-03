using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("currentPlayerSprite", "totalMoney")]
	public class ES3UserType_GameProperties : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_GameProperties() : base(typeof(GameProperties)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (GameProperties)obj;
			
			writer.WritePrivateFieldByRef("currentPlayerSprite", instance);
			writer.WritePrivateField("totalMoney", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (GameProperties)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "currentPlayerSprite":
					reader.SetPrivateField("currentPlayerSprite", reader.Read<UnityEngine.Sprite>(), instance);
					break;
					case "totalMoney":
					reader.SetPrivateField("totalMoney", reader.Read<System.Int32>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_GamePropertiesArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_GamePropertiesArray() : base(typeof(GameProperties[]), ES3UserType_GameProperties.Instance)
		{
			Instance = this;
		}
	}
}