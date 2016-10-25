using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Models
{
	public class ConvertHelper
	{
		public static T Data2Model<T>(DataRow dr) where T : new()
		{
			T model = new T();

			foreach (PropertyInfo field in typeof(T).GetProperties())
			{
				string columnName = string.Empty;
				object[] attrs = field.GetCustomAttributes(typeof(Alias), false);

				if (attrs.Length > 0)
					columnName = ((Alias)attrs[0]).Name;
				else
					columnName = field.Name;

				if (field.CanWrite && dr.Table.Columns.Contains(columnName))
				{
					if (!dr.IsNull(columnName))
					{
						field.SetValue(model, dr[columnName]);
					}
				}
			}

			return model;
		}

		public static void Copy<ParentClass>(ParentClass source, ParentClass target)
		{
			foreach (PropertyInfo field in typeof(ParentClass).GetProperties())
			{
				if (field.CanRead && field.CanWrite)
				{
					field.SetValue(target, field.GetValue(source));
				}
			}
		}

		public static List<T> Data2List<T>(DataTable dt) where T : new()
		{
			List<T> models = new List<T>();

			Dictionary<string, PropertyInfo> columns = new Dictionary<string, PropertyInfo>();

			foreach (PropertyInfo field in typeof(T).GetProperties())
			{
				string column = string.Empty;
				object[] attrs = field.GetCustomAttributes(typeof(Alias), false);

				if (attrs.Length > 0)
					column = ((Alias)attrs[0]).Name;
				else
					column = field.Name;

				if (field.CanWrite && dt.Columns.Contains(column))
				{
					columns.Add(column, field);
				}
			}

			foreach (DataRow dr in dt.Rows)
			{
				T model = new T();

				foreach (var item in columns)
				{
					if (!dr.IsNull(item.Key))
					{
						item.Value.SetValue(model, dr[item.Key], null);
					}
				}

				models.Add(model);
			}

			return models;
		}

		public static T NameValue2Model<T>(global::System.Collections.Specialized.NameValueCollection data) where T : new()
		{
			T model = new T();

			foreach (PropertyInfo field in typeof(T).GetProperties())
			{
				foreach (string key in data.AllKeys)
				{
					if (field.Name.Equals(key) && field.CanWrite)
					{
						object value = null;

						Type changedType = !field.PropertyType.IsGenericType
							? field.PropertyType
							: Nullable.GetUnderlyingType(field.PropertyType);

						value = string.IsNullOrEmpty(data[key])
							? null
							: Convert.ChangeType(data[key], changedType);

						field.SetValue(model, value, null);
					}
				}
			}

			return model;
		}
	}

	[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
	public sealed class Alias : Attribute
	{
		private readonly string name;

		public Alias(string name)
		{
			this.name = name;
		}

		public string Name
		{
			get { return name; }
		}
	}
}
