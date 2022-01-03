using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_Sprite", "m_Color", "sprite", "color")]
	public class ES3UserType_Image : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Image() : base(typeof(UnityEngine.UI.Image)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.UI.Image)obj;
			
			writer.WritePrivateFieldByRef("m_Sprite", instance);
			writer.WritePrivateField("m_Color", instance);
			writer.WritePropertyByRef("sprite", instance.sprite);
			writer.WriteProperty("color", instance.color, ES3Type_Color.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.UI.Image)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_Sprite":
					reader.SetPrivateField("m_Sprite", reader.Read<UnityEngine.Sprite>(), instance);
					break;
					case "m_Color":
					reader.SetPrivateField("m_Color", reader.Read<UnityEngine.Color>(), instance);
					break;
					case "sprite":
						instance.sprite = reader.Read<UnityEngine.Sprite>(ES3Type_Sprite.Instance);
						break;
					case "color":
						instance.color = reader.Read<UnityEngine.Color>(ES3Type_Color.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_ImageArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ImageArray() : base(typeof(UnityEngine.UI.Image[]), ES3UserType_Image.Instance)
		{
			Instance = this;
		}
	}
}