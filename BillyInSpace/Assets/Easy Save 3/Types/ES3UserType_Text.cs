using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("text", "fontSize", "color")]
	public class ES3UserType_Text : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Text() : base(typeof(UnityEngine.UI.Text)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.UI.Text)obj;
			
			writer.WriteProperty("text", instance.text, ES3Type_string.Instance);
			writer.WriteProperty("fontSize", instance.fontSize, ES3Type_int.Instance);
			writer.WriteProperty("color", instance.color, ES3Type_Color.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.UI.Text)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "text":
						instance.text = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					case "fontSize":
						instance.fontSize = reader.Read<System.Int32>(ES3Type_int.Instance);
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


	public class ES3UserType_TextArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TextArray() : base(typeof(UnityEngine.UI.Text[]), ES3UserType_Text.Instance)
		{
			Instance = this;
		}
	}
}