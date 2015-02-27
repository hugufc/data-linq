﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Linq.Mapping;
using System.Data.Linq.SqlClient;
using System.Reflection;
using Mindbox.Data.Linq.Mapping;

namespace System.Data.Entity.ModelConfiguration.Configuration
{
	/// <summary>
	/// Used to configure a primitive property of an entity type or complex type.
	/// </summary>
	public class PrimitivePropertyConfiguration
	{
		private string columnName;
		private string columnType;
		private bool? canBeNull;
		private bool? isConcurrencyToken;
		private DatabaseGeneratedOption? databaseGeneratedOption;


		internal PrimitivePropertyConfiguration(PropertyInfo property)
		{
			if (property == null)
				throw new ArgumentNullException("property");

			Property = property;
		}


		internal PropertyInfo Property { get; private set; }


		/// <summary>
		/// Configures the property to be optional.
		/// The database column used to store this property will be nullable.
		/// </summary>
		/// <returns> The same PrimitivePropertyConfiguration instance so that multiple calls can be chained. </returns>
		public PrimitivePropertyConfiguration IsOptional()
		{
			canBeNull = true;
			return this;
		}

		/// <summary>
		/// Configures the property to be required.
		/// The database column used to store this property will be non-nullable.
		/// </summary>
		/// <returns> The same PrimitivePropertyConfiguration instance so that multiple calls can be chained. </returns>
		public PrimitivePropertyConfiguration IsRequired()
		{
			canBeNull = false;
			return this;
		}

		/// <summary>
		/// Configures how values for the property are generated by the database.
		/// </summary>
		/// <param name="databaseGeneratedOption">
		/// The pattern used to generate values for the property in the database.
		/// Setting 'null' will cause the default option to be used, which may be 'None', 'Identity', or 'Computed' depending
		/// on the type of the property, its semantics in the model (e.g. primary keys are treated differently), and which
		/// set of conventions are being used.
		/// </param>
		/// <returns> The same PrimitivePropertyConfiguration instance so that multiple calls can be chained. </returns>
		public PrimitivePropertyConfiguration HasDatabaseGeneratedOption(
			DatabaseGeneratedOption? databaseGeneratedOption)
		{
			this.databaseGeneratedOption = databaseGeneratedOption;
			return this;
		}

		/// <summary>
		/// Configures the property to be used as an optimistic concurrency token.
		/// </summary>
		/// <returns> The same PrimitivePropertyConfiguration instance so that multiple calls can be chained. </returns>
		public PrimitivePropertyConfiguration IsConcurrencyToken()
		{
			isConcurrencyToken = true;
			return this;
		}

		/// <summary>
		/// Configures whether or not the property is to be used as an optimistic concurrency token.
		/// </summary>
		/// <param name="concurrencyToken"> Value indicating if the property is a concurrency token or not. Specifying 'null' will remove the concurrency token facet from the property. Specifying 'null' will cause the same runtime behavior as specifying 'false'. </param>
		/// <returns> The same PrimitivePropertyConfiguration instance so that multiple calls can be chained. </returns>
		public PrimitivePropertyConfiguration IsConcurrencyToken(bool? concurrencyToken)
		{
			isConcurrencyToken = concurrencyToken;
			return this;
		}

		/// <summary>
		/// Configures the data type of the database column used to store the property.
		/// </summary>
		/// <param name="columnType"> Name of the database provider specific data type. </param>
		/// <returns> The same PrimitivePropertyConfiguration instance so that multiple calls can be chained. </returns>
		public PrimitivePropertyConfiguration HasColumnType(string columnType)
		{
			this.columnType = string.IsNullOrEmpty(columnType) ? null : columnType;
			return this;
		}

		/// <summary>
		/// Configures the name of the database column used to store the property.
		/// </summary>
		/// <param name="columnName"> The name of the column. </param>
		/// <returns> The same PrimitivePropertyConfiguration instance so that multiple calls can be chained. </returns>
		public PrimitivePropertyConfiguration HasColumnName(string columnName)
		{
			this.columnName = string.IsNullOrEmpty(columnName) ? null : columnName;
			return this;
		}

		/// <summary>
		/// Configures the order of the database column used to store the property.
		/// This method is also used to specify key ordering when an entity type has a composite key.
		/// </summary>
		/// <param name="columnOrder"> The order that this column should appear in the database table. </param>
		/// <returns> The same PrimitivePropertyConfiguration instance so that multiple calls can be chained. </returns>
		public PrimitivePropertyConfiguration HasColumnOrder(int? columnOrder)
		{
			if (columnOrder < 0)
				throw new ArgumentOutOfRangeException("columnOrder");

			throw new NotImplementedException();
		}


		protected virtual string BuildDbTypeWithoutNullability(Linq.Mapping.ColumnAttribute columnAttribute)
		{
			if (columnAttribute == null)
				throw new ArgumentNullException("columnAttribute");

			var dbType = GetEffectiveColumnType();
			if (databaseGeneratedOption == DatabaseGeneratedOption.Identity)
				dbType += " identity";
			return dbType;
		}


		internal virtual string GetEffectiveColumnType()
		{
			if (columnType != null)
				return columnType;
			if ((Property.PropertyType == typeof(bool)) || (Property.PropertyType == typeof(bool?)))
				return "bit";
			if ((Property.PropertyType == typeof(int)) || (Property.PropertyType == typeof(int?)))
				return "int";
			return null;
		}

		internal ColumnAttributeByMember GetColumnAttribute()
		{
			var columnAttribute = new Linq.Mapping.ColumnAttribute
			{
				Name = columnName,
				CanBeNull = canBeNull ?? 
					TypeSystem.IsNullableType(Property.PropertyType) || !Property.PropertyType.IsValueType,
				IsVersion = isConcurrencyToken ?? false
			};
			switch (databaseGeneratedOption)
			{
				case DatabaseGeneratedOption.Identity:
					columnAttribute.AutoSync = AutoSync.OnInsert;
					columnAttribute.IsDbGenerated = true;
					break;

				case DatabaseGeneratedOption.Computed:
					columnAttribute.AutoSync = AutoSync.Always;
					columnAttribute.IsDbGenerated = true;
					break;

				default:
					columnAttribute.AutoSync = AutoSync.Never;
					columnAttribute.IsDbGenerated = false;
					break;
			}
			columnAttribute.DbType = BuildDbType(columnAttribute);
			return new ColumnAttributeByMember
			{
				Member = Property,
				Attribute = columnAttribute
			};
		}

		internal virtual PrimitivePropertyConfiguration Clone(PropertyInfo newProperty)
		{
			if (newProperty == null)
				throw new ArgumentNullException("newProperty");

			var clone = (PrimitivePropertyConfiguration)MemberwiseClone();
			clone.Property = newProperty;
			return clone;
		}


		private string BuildDbType(Linq.Mapping.ColumnAttribute columnAttribute)
		{
			if (columnAttribute == null)
				throw new ArgumentNullException("columnAttribute");

			var dbTypeWithoutNullability = BuildDbTypeWithoutNullability(columnAttribute);
			return dbTypeWithoutNullability == null ? 
				null : 
				dbTypeWithoutNullability + (columnAttribute.CanBeNull ? " null" : " not null");
		}
	}
}