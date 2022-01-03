using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("image")]
	public class ES3UserType_Button : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Button() : base(typeof(UnityEngine.UI.Button)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.UI.Button)obj;
			
			writer.WritePropertyByRef("image", instance.image);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.UI.Button)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "image":
						instance.image = reader.Read<UnityEngine.UI.Image>(ES3UserType_Image.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_ButtonArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ButtonArray() : base(typeof(UnityEngine.UI.Button[]), ES3UserType_Button.Instance)
		{
			Instance = this;
		}
	}
}