﻿using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mindbox.Data.Linq.Mapping;

namespace Mindbox.Data.Linq.Tests
{
	[TestClass]
	public class DbModelBuilderTests
	{
		[TestMethod]
		public void TableAttributeViaAttribute()
		{
			var incompatibilityDetected = false;
			var configuration = new MindboxMappingConfiguration();
			configuration.EntityFrameworkIncompatibility += (sender, incompatibility) =>
			{
				if (incompatibility == EntityFrameworkIncompatibility.TableAttribute)
					incompatibilityDetected = true;
			};
			var mappingSource = new MindboxMappingSource(configuration);
			var metaTable = mappingSource.GetModel(typeof(DataContext)).GetTable(typeof(TestEntity4));

			Assert.IsNotNull(metaTable);
			Assert.AreEqual("administration.Staff", metaTable.TableName);
			Assert.IsTrue(incompatibilityDetected);
		}

		[TestMethod]
		public void TableAttributeViaBuilder()
		{
			var configuration = new MindboxMappingConfiguration();
			configuration.ModelBuilder.Configurations.Add(new TestEntity6.TestEntity6Configuration());

			var mappingSource = new MindboxMappingSource(configuration);
			var metaTable = mappingSource.GetModel(typeof(DataContext)).GetTable(typeof(TestEntity6));

			Assert.IsNotNull(metaTable);
			Assert.AreEqual("administration.Staff", metaTable.TableName);
		}

		[TestMethod]
		public void BooleanColumnViaAttribute()
		{
			var configuration = new MindboxMappingConfiguration();
			var mappingSource = new MindboxMappingSource(configuration);
			var metaDataMember = mappingSource
				.GetModel(typeof(DataContext))
				.GetMetaType(typeof(TestEntity4))
				.DataMembers
				.SingleOrDefault(aMetaDataMember => aMetaDataMember.Name == "IsBlocked");

			Assert.IsNotNull(metaDataMember);
			Assert.AreEqual("IsBlocked", metaDataMember.MappedName);
			Assert.IsNull(metaDataMember.Association);
			Assert.AreEqual(AutoSync.Never, metaDataMember.AutoSync);
			Assert.IsFalse(metaDataMember.CanBeNull);
			Assert.AreEqual("bit not null", metaDataMember.DbType);
			Assert.IsNull(metaDataMember.Expression);
			Assert.IsFalse(metaDataMember.IsAssociation);
			Assert.IsFalse(metaDataMember.IsDbGenerated);
			Assert.IsFalse(metaDataMember.IsDeferred);
			Assert.IsFalse(metaDataMember.IsDiscriminator);
			Assert.IsTrue(metaDataMember.IsPersistent);
			Assert.IsFalse(metaDataMember.IsPrimaryKey);
			Assert.IsFalse(metaDataMember.IsVersion);
			Assert.AreEqual(typeof(bool), metaDataMember.Type);
			Assert.AreEqual(UpdateCheck.Always, metaDataMember.UpdateCheck);
		}

		[TestMethod]
		public void BooleanColumnViaBuilder()
		{
			var configuration = new MindboxMappingConfiguration();
			configuration.ModelBuilder.Configurations.Add(new TestEntity6.TestEntity6Configuration());

			var mappingSource = new MindboxMappingSource(configuration);
			var metaDataMember = mappingSource
				.GetModel(typeof(DataContext))
				.GetMetaType(typeof(TestEntity6))
				.DataMembers
				.SingleOrDefault(aMetaDataMember => aMetaDataMember.Name == "IsBlocked");

			Assert.IsNotNull(metaDataMember);
			Assert.AreEqual("IsBlocked", metaDataMember.MappedName);
			Assert.IsNull(metaDataMember.Association);
			Assert.AreEqual(AutoSync.Never, metaDataMember.AutoSync);
			Assert.IsFalse(metaDataMember.CanBeNull);
			Assert.AreEqual("bit not null", metaDataMember.DbType);
			Assert.IsNull(metaDataMember.Expression);
			Assert.IsFalse(metaDataMember.IsAssociation);
			Assert.IsFalse(metaDataMember.IsDbGenerated);
			Assert.IsFalse(metaDataMember.IsDeferred);
			Assert.IsFalse(metaDataMember.IsDiscriminator);
			Assert.IsTrue(metaDataMember.IsPersistent);
			Assert.IsFalse(metaDataMember.IsPrimaryKey);
			Assert.IsFalse(metaDataMember.IsVersion);
			Assert.AreEqual(typeof(bool), metaDataMember.Type);
			Assert.AreEqual(UpdateCheck.Always, metaDataMember.UpdateCheck);
		}

		[TestMethod]
		public void NvarcharNotNullColumnViaAttribute()
		{
			var configuration = new MindboxMappingConfiguration();
			var mappingSource = new MindboxMappingSource(configuration);
			var metaDataMember = mappingSource
				.GetModel(typeof(DataContext))
				.GetMetaType(typeof(TestEntity4))
				.DataMembers
				.SingleOrDefault(aMetaDataMember => aMetaDataMember.Name == "UserName");

			Assert.IsNotNull(metaDataMember);
			Assert.AreEqual("UserName", metaDataMember.MappedName);
			Assert.IsNull(metaDataMember.Association);
			Assert.AreEqual(AutoSync.Never, metaDataMember.AutoSync);
			Assert.IsFalse(metaDataMember.CanBeNull);
			Assert.AreEqual("nvarchar(100) not null", metaDataMember.DbType);
			Assert.IsNull(metaDataMember.Expression);
			Assert.IsFalse(metaDataMember.IsAssociation);
			Assert.IsFalse(metaDataMember.IsDbGenerated);
			Assert.IsFalse(metaDataMember.IsDeferred);
			Assert.IsFalse(metaDataMember.IsDiscriminator);
			Assert.IsTrue(metaDataMember.IsPersistent);
			Assert.IsFalse(metaDataMember.IsPrimaryKey);
			Assert.IsFalse(metaDataMember.IsVersion);
			Assert.AreEqual(typeof(string), metaDataMember.Type);
			Assert.AreEqual(UpdateCheck.Always, metaDataMember.UpdateCheck);
		}

		[TestMethod]
		public void NvarcharNotNullColumnViaBuilder()
		{
			var configuration = new MindboxMappingConfiguration();
			configuration.ModelBuilder.Configurations.Add(new TestEntity6.TestEntity6Configuration());

			var mappingSource = new MindboxMappingSource(configuration);
			var metaDataMember = mappingSource
				.GetModel(typeof(DataContext))
				.GetMetaType(typeof(TestEntity6))
				.DataMembers
				.SingleOrDefault(aMetaDataMember => aMetaDataMember.Name == "UserName");

			Assert.IsNotNull(metaDataMember);
			Assert.AreEqual("UserName", metaDataMember.MappedName);
			Assert.IsNull(metaDataMember.Association);
			Assert.AreEqual(AutoSync.Never, metaDataMember.AutoSync);
			Assert.IsFalse(metaDataMember.CanBeNull);
			Assert.AreEqual("nvarchar(100) not null", metaDataMember.DbType);
			Assert.IsNull(metaDataMember.Expression);
			Assert.IsFalse(metaDataMember.IsAssociation);
			Assert.IsFalse(metaDataMember.IsDbGenerated);
			Assert.IsFalse(metaDataMember.IsDeferred);
			Assert.IsFalse(metaDataMember.IsDiscriminator);
			Assert.IsTrue(metaDataMember.IsPersistent);
			Assert.IsFalse(metaDataMember.IsPrimaryKey);
			Assert.IsFalse(metaDataMember.IsVersion);
			Assert.AreEqual(typeof(string), metaDataMember.Type);
			Assert.AreEqual(UpdateCheck.Always, metaDataMember.UpdateCheck);
		}

		[TestMethod]
		public void CharNullColumnViaAttribute()
		{
			var configuration = new MindboxMappingConfiguration();
			var mappingSource = new MindboxMappingSource(configuration);
			var metaDataMember = mappingSource
				.GetModel(typeof(DataContext))
				.GetMetaType(typeof(TestEntity4))
				.DataMembers
				.SingleOrDefault(aMetaDataMember => aMetaDataMember.Name == "PasswordHash");

			Assert.IsNotNull(metaDataMember);
			Assert.AreEqual("PasswordHash", metaDataMember.MappedName);
			Assert.IsNull(metaDataMember.Association);
			Assert.AreEqual(AutoSync.Never, metaDataMember.AutoSync);
			Assert.IsTrue(metaDataMember.CanBeNull);
			Assert.AreEqual("char(40) null", metaDataMember.DbType);
			Assert.IsNull(metaDataMember.Expression);
			Assert.IsFalse(metaDataMember.IsAssociation);
			Assert.IsFalse(metaDataMember.IsDbGenerated);
			Assert.IsFalse(metaDataMember.IsDeferred);
			Assert.IsFalse(metaDataMember.IsDiscriminator);
			Assert.IsTrue(metaDataMember.IsPersistent);
			Assert.IsFalse(metaDataMember.IsPrimaryKey);
			Assert.IsFalse(metaDataMember.IsVersion);
			Assert.AreEqual(typeof(string), metaDataMember.Type);
			Assert.AreEqual(UpdateCheck.Always, metaDataMember.UpdateCheck);
		}

		[TestMethod]
		public void CharNullColumnViaBuilder()
		{
			var configuration = new MindboxMappingConfiguration();
			configuration.ModelBuilder.Configurations.Add(new TestEntity6.TestEntity6Configuration());

			var mappingSource = new MindboxMappingSource(configuration);
			var metaDataMember = mappingSource
				.GetModel(typeof(DataContext))
				.GetMetaType(typeof(TestEntity6))
				.DataMembers
				.SingleOrDefault(aMetaDataMember => aMetaDataMember.Name == "PasswordHash");

			Assert.IsNotNull(metaDataMember);
			Assert.AreEqual("PasswordHash", metaDataMember.MappedName);
			Assert.IsNull(metaDataMember.Association);
			Assert.AreEqual(AutoSync.Never, metaDataMember.AutoSync);
			Assert.IsTrue(metaDataMember.CanBeNull);
			Assert.AreEqual("char(40) null", metaDataMember.DbType);
			Assert.IsNull(metaDataMember.Expression);
			Assert.IsFalse(metaDataMember.IsAssociation);
			Assert.IsFalse(metaDataMember.IsDbGenerated);
			Assert.IsFalse(metaDataMember.IsDeferred);
			Assert.IsFalse(metaDataMember.IsDiscriminator);
			Assert.IsTrue(metaDataMember.IsPersistent);
			Assert.IsFalse(metaDataMember.IsPrimaryKey);
			Assert.IsFalse(metaDataMember.IsVersion);
			Assert.AreEqual(typeof(string), metaDataMember.Type);
			Assert.AreEqual(UpdateCheck.Always, metaDataMember.UpdateCheck);
		}

		[TestMethod]
		public void NvarcharMaxNotNullColumnViaAttribute()
		{
			var configuration = new MindboxMappingConfiguration();
			var mappingSource = new MindboxMappingSource(configuration);
			var metaDataMember = mappingSource
				.GetModel(typeof(DataContext))
				.GetMetaType(typeof(TestEntity4))
				.DataMembers
				.SingleOrDefault(aMetaDataMember => aMetaDataMember.Name == "Comment");

			Assert.IsNotNull(metaDataMember);
			Assert.AreEqual("Comment", metaDataMember.MappedName);
			Assert.IsNull(metaDataMember.Association);
			Assert.AreEqual(AutoSync.Never, metaDataMember.AutoSync);
			Assert.IsFalse(metaDataMember.CanBeNull);
			Assert.AreEqual("nvarchar(max) not null", metaDataMember.DbType);
			Assert.IsNull(metaDataMember.Expression);
			Assert.IsFalse(metaDataMember.IsAssociation);
			Assert.IsFalse(metaDataMember.IsDbGenerated);
			Assert.IsFalse(metaDataMember.IsDeferred);
			Assert.IsFalse(metaDataMember.IsDiscriminator);
			Assert.IsTrue(metaDataMember.IsPersistent);
			Assert.IsFalse(metaDataMember.IsPrimaryKey);
			Assert.IsFalse(metaDataMember.IsVersion);
			Assert.AreEqual(typeof(string), metaDataMember.Type);
			Assert.AreEqual(UpdateCheck.Always, metaDataMember.UpdateCheck);
		}

		[TestMethod]
		public void NvarcharMaxNotNullColumnViaBuilder()
		{
			var configuration = new MindboxMappingConfiguration();
			configuration.ModelBuilder.Configurations.Add(new TestEntity6.TestEntity6Configuration());

			var mappingSource = new MindboxMappingSource(configuration);
			var metaDataMember = mappingSource
				.GetModel(typeof(DataContext))
				.GetMetaType(typeof(TestEntity6))
				.DataMembers
				.SingleOrDefault(aMetaDataMember => aMetaDataMember.Name == "Comment");

			Assert.IsNotNull(metaDataMember);
			Assert.AreEqual("Comment", metaDataMember.MappedName);
			Assert.IsNull(metaDataMember.Association);
			Assert.AreEqual(AutoSync.Never, metaDataMember.AutoSync);
			Assert.IsFalse(metaDataMember.CanBeNull);
			Assert.AreEqual("nvarchar(max) not null", metaDataMember.DbType);
			Assert.IsNull(metaDataMember.Expression);
			Assert.IsFalse(metaDataMember.IsAssociation);
			Assert.IsFalse(metaDataMember.IsDbGenerated);
			Assert.IsFalse(metaDataMember.IsDeferred);
			Assert.IsFalse(metaDataMember.IsDiscriminator);
			Assert.IsTrue(metaDataMember.IsPersistent);
			Assert.IsFalse(metaDataMember.IsPrimaryKey);
			Assert.IsFalse(metaDataMember.IsVersion);
			Assert.AreEqual(typeof(string), metaDataMember.Type);
			Assert.AreEqual(UpdateCheck.Always, metaDataMember.UpdateCheck);
		}

		[TestMethod]
		public void DateTimeColumnViaAttribute()
		{
			var configuration = new MindboxMappingConfiguration();
			var mappingSource = new MindboxMappingSource(configuration);
			var metaDataMember = mappingSource
				.GetModel(typeof(DataContext))
				.GetMetaType(typeof(TestEntity4))
				.DataMembers
				.SingleOrDefault(aMetaDataMember => aMetaDataMember.Name == "CreationDateTimeUtc");

			Assert.IsNotNull(metaDataMember);
			Assert.AreEqual("CreationDateTimeUtc", metaDataMember.MappedName);
			Assert.IsNull(metaDataMember.Association);
			Assert.AreEqual(AutoSync.Never, metaDataMember.AutoSync);
			Assert.IsFalse(metaDataMember.CanBeNull);
			Assert.AreEqual("datetime not null", metaDataMember.DbType);
			Assert.IsNull(metaDataMember.Expression);
			Assert.IsFalse(metaDataMember.IsAssociation);
			Assert.IsFalse(metaDataMember.IsDbGenerated);
			Assert.IsFalse(metaDataMember.IsDeferred);
			Assert.IsFalse(metaDataMember.IsDiscriminator);
			Assert.IsTrue(metaDataMember.IsPersistent);
			Assert.IsFalse(metaDataMember.IsPrimaryKey);
			Assert.IsFalse(metaDataMember.IsVersion);
			Assert.AreEqual(typeof(DateTime), metaDataMember.Type);
			Assert.AreEqual(UpdateCheck.Always, metaDataMember.UpdateCheck);
		}

		[TestMethod]
		public void DateTimeColumnViaBuilder()
		{
			var configuration = new MindboxMappingConfiguration();
			configuration.ModelBuilder.Configurations.Add(new TestEntity6.TestEntity6Configuration());

			var mappingSource = new MindboxMappingSource(configuration);
			var metaDataMember = mappingSource
				.GetModel(typeof(DataContext))
				.GetMetaType(typeof(TestEntity6))
				.DataMembers
				.SingleOrDefault(aMetaDataMember => aMetaDataMember.Name == "CreationDateTimeUtc");

			Assert.IsNotNull(metaDataMember);
			Assert.AreEqual("CreationDateTimeUtc", metaDataMember.MappedName);
			Assert.IsNull(metaDataMember.Association);
			Assert.AreEqual(AutoSync.Never, metaDataMember.AutoSync);
			Assert.IsFalse(metaDataMember.CanBeNull);
			Assert.AreEqual("datetime not null", metaDataMember.DbType);
			Assert.IsNull(metaDataMember.Expression);
			Assert.IsFalse(metaDataMember.IsAssociation);
			Assert.IsFalse(metaDataMember.IsDbGenerated);
			Assert.IsFalse(metaDataMember.IsDeferred);
			Assert.IsFalse(metaDataMember.IsDiscriminator);
			Assert.IsTrue(metaDataMember.IsPersistent);
			Assert.IsFalse(metaDataMember.IsPrimaryKey);
			Assert.IsFalse(metaDataMember.IsVersion);
			Assert.AreEqual(typeof(DateTime), metaDataMember.Type);
			Assert.AreEqual(UpdateCheck.Always, metaDataMember.UpdateCheck);
		}

		[TestMethod]
		public void NullableDateTimeColumnViaAttribute()
		{
			var configuration = new MindboxMappingConfiguration();
			var mappingSource = new MindboxMappingSource(configuration);
			var metaDataMember = mappingSource
				.GetModel(typeof(DataContext))
				.GetMetaType(typeof(TestEntity4))
				.DataMembers
				.SingleOrDefault(aMetaDataMember => aMetaDataMember.Name == "AccountExpirationDateTimeUtc");

			Assert.IsNotNull(metaDataMember);
			Assert.AreEqual("AccountExpirationDateTimeUtc", metaDataMember.MappedName);
			Assert.IsNull(metaDataMember.Association);
			Assert.AreEqual(AutoSync.Never, metaDataMember.AutoSync);
			Assert.IsTrue(metaDataMember.CanBeNull);
			Assert.AreEqual("datetime null", metaDataMember.DbType);
			Assert.IsNull(metaDataMember.Expression);
			Assert.IsFalse(metaDataMember.IsAssociation);
			Assert.IsFalse(metaDataMember.IsDbGenerated);
			Assert.IsFalse(metaDataMember.IsDeferred);
			Assert.IsFalse(metaDataMember.IsDiscriminator);
			Assert.IsTrue(metaDataMember.IsPersistent);
			Assert.IsFalse(metaDataMember.IsPrimaryKey);
			Assert.IsFalse(metaDataMember.IsVersion);
			Assert.AreEqual(typeof(DateTime?), metaDataMember.Type);
			Assert.AreEqual(UpdateCheck.Always, metaDataMember.UpdateCheck);
		}

		[TestMethod]
		public void NullableDateTimeColumnViaBuilder()
		{
			var configuration = new MindboxMappingConfiguration();
			configuration.ModelBuilder.Configurations.Add(new TestEntity6.TestEntity6Configuration());

			var mappingSource = new MindboxMappingSource(configuration);
			var metaDataMember = mappingSource
				.GetModel(typeof(DataContext))
				.GetMetaType(typeof(TestEntity6))
				.DataMembers
				.SingleOrDefault(aMetaDataMember => aMetaDataMember.Name == "AccountExpirationDateTimeUtc");

			Assert.IsNotNull(metaDataMember);
			Assert.AreEqual("AccountExpirationDateTimeUtc", metaDataMember.MappedName);
			Assert.IsNull(metaDataMember.Association);
			Assert.AreEqual(AutoSync.Never, metaDataMember.AutoSync);
			Assert.IsTrue(metaDataMember.CanBeNull);
			Assert.AreEqual("datetime null", metaDataMember.DbType);
			Assert.IsNull(metaDataMember.Expression);
			Assert.IsFalse(metaDataMember.IsAssociation);
			Assert.IsFalse(metaDataMember.IsDbGenerated);
			Assert.IsFalse(metaDataMember.IsDeferred);
			Assert.IsFalse(metaDataMember.IsDiscriminator);
			Assert.IsTrue(metaDataMember.IsPersistent);
			Assert.IsFalse(metaDataMember.IsPrimaryKey);
			Assert.IsFalse(metaDataMember.IsVersion);
			Assert.AreEqual(typeof(DateTime?), metaDataMember.Type);
			Assert.AreEqual(UpdateCheck.Always, metaDataMember.UpdateCheck);
		}

		[TestMethod]
		public void VersionColumnViaAttribute()
		{
			var configuration = new MindboxMappingConfiguration();
			var mappingSource = new MindboxMappingSource(configuration);
			var metaDataMember = mappingSource
				.GetModel(typeof(DataContext))
				.GetMetaType(typeof(TestEntity4))
				.DataMembers
				.SingleOrDefault(aMetaDataMember => aMetaDataMember.Name == "RowVersion");

			Assert.IsNotNull(metaDataMember);
			Assert.AreEqual("RowVersion", metaDataMember.MappedName);
			Assert.IsNull(metaDataMember.Association);
			Assert.AreEqual(AutoSync.Always, metaDataMember.AutoSync);
			Assert.IsFalse(metaDataMember.CanBeNull);
			Assert.AreEqual("rowversion not null", metaDataMember.DbType);
			Assert.IsNull(metaDataMember.Expression);
			Assert.IsFalse(metaDataMember.IsAssociation);
			Assert.IsTrue(metaDataMember.IsDbGenerated);
			Assert.IsFalse(metaDataMember.IsDeferred);
			Assert.IsFalse(metaDataMember.IsDiscriminator);
			Assert.IsTrue(metaDataMember.IsPersistent);
			Assert.IsFalse(metaDataMember.IsPrimaryKey);
			Assert.IsTrue(metaDataMember.IsVersion);
			Assert.AreEqual(typeof(Binary), metaDataMember.Type);
			Assert.AreEqual(UpdateCheck.Always, metaDataMember.UpdateCheck);
		}

		[TestMethod]
		public void VersionColumnViaBuilder()
		{
			var configuration = new MindboxMappingConfiguration();
			configuration.ModelBuilder.Configurations.Add(new TestEntity6.TestEntity6Configuration());

			var mappingSource = new MindboxMappingSource(configuration);
			var metaDataMember = mappingSource
				.GetModel(typeof(DataContext))
				.GetMetaType(typeof(TestEntity6))
				.DataMembers
				.SingleOrDefault(aMetaDataMember => aMetaDataMember.Name == "RowVersion");

			Assert.IsNotNull(metaDataMember);
			Assert.AreEqual("RowVersion", metaDataMember.MappedName);
			Assert.IsNull(metaDataMember.Association);
			Assert.AreEqual(AutoSync.Always, metaDataMember.AutoSync);
			Assert.IsFalse(metaDataMember.CanBeNull);
			Assert.AreEqual("rowversion not null", metaDataMember.DbType);
			Assert.IsNull(metaDataMember.Expression);
			Assert.IsFalse(metaDataMember.IsAssociation);
			Assert.IsTrue(metaDataMember.IsDbGenerated);
			Assert.IsFalse(metaDataMember.IsDeferred);
			Assert.IsFalse(metaDataMember.IsDiscriminator);
			Assert.IsTrue(metaDataMember.IsPersistent);
			Assert.IsFalse(metaDataMember.IsPrimaryKey);
			Assert.IsTrue(metaDataMember.IsVersion);
			Assert.AreEqual(typeof(byte[]), metaDataMember.Type);
			Assert.AreEqual(UpdateCheck.Always, metaDataMember.UpdateCheck);
		}

		[TestMethod]
		public void BinaryColumnViaBuilderRealDatabase()
		{
			var configuration = new MindboxMappingConfiguration();
			configuration.ModelBuilder.Configurations.Add(new TestEntity8.TestEntity8Configuration());

			var mappingSource = new MindboxMappingSource(configuration);

			using (var connection = new SqlConnection("Server=(local);Integrated Security=SSPI;Pooling=false"))
			{
				connection.Open();

				var createDatabaseCommand = new SqlCommand("create database MindboxDataLinqTests", connection);
				createDatabaseCommand.ExecuteNonQuery();
				try
				{
					var createTableCommand = new SqlCommand(
						"create table MindboxDataLinqTests.dbo.Test8 " +
							"(Id int identity(1,1) not null primary key, Value binary(5) not null)",
						connection);
					createTableCommand.ExecuteNonQuery();

					var insertCommand = new SqlCommand(
						"insert into MindboxDataLinqTests.dbo.Test8 (Value) values (0x1122334455)", 
						connection);
					insertCommand.ExecuteNonQuery();

					using (var context = new DataContext(
						"Server=(local);Integrated Security=SSPI;Database=MindboxDataLinqTests;Pooling=false", 
						mappingSource))
					{
						var item = context.GetTable<TestEntity8>().Single();
						Assert.IsNotNull(item.Value);
						Assert.AreEqual(5, item.Value.Length);
						Assert.AreEqual(0x11, item.Value[0]);
						Assert.AreEqual(0x22, item.Value[1]);
						Assert.AreEqual(0x33, item.Value[2]);
						Assert.AreEqual(0x44, item.Value[3]);
						Assert.AreEqual(0x55, item.Value[4]);

						item.Value = new byte[]
						{
							1,
							2,
							3,
							4,
							5
						};
						context.SubmitChanges();
					}

					using (var context = new DataContext(
						"Server=(local);Integrated Security=SSPI;Database=MindboxDataLinqTests;Pooling=false",
						mappingSource))
					{
						var item = context.GetTable<TestEntity8>().Single();
						Assert.IsNotNull(item.Value);
						Assert.AreEqual(5, item.Value.Length);
						Assert.AreEqual(1, item.Value[0]);
						Assert.AreEqual(2, item.Value[1]);
						Assert.AreEqual(3, item.Value[2]);
						Assert.AreEqual(4, item.Value[3]);
						Assert.AreEqual(5, item.Value[4]);
					}
				}
				finally
				{
					var dropDatabaseCommand = new SqlCommand("drop database MindboxDataLinqTests", connection);
					dropDatabaseCommand.ExecuteNonQuery();
				}
			}
		}

		[TestMethod]
		public void IdentityColumnViaAttribute()
		{
			var configuration = new MindboxMappingConfiguration();
			var mappingSource = new MindboxMappingSource(configuration);
			var metaDataMember = mappingSource
				.GetModel(typeof(DataContext))
				.GetMetaType(typeof(TestEntity4))
				.DataMembers
				.SingleOrDefault(aMetaDataMember => aMetaDataMember.Name == "Id");

			Assert.IsNotNull(metaDataMember);
			Assert.AreEqual("Id", metaDataMember.MappedName);
			Assert.IsNull(metaDataMember.Association);
			Assert.AreEqual(AutoSync.OnInsert, metaDataMember.AutoSync);
			Assert.IsFalse(metaDataMember.CanBeNull);
			Assert.AreEqual("int identity not null", metaDataMember.DbType);
			Assert.IsNull(metaDataMember.Expression);
			Assert.IsFalse(metaDataMember.IsAssociation);
			Assert.IsTrue(metaDataMember.IsDbGenerated);
			Assert.IsFalse(metaDataMember.IsDeferred);
			Assert.IsFalse(metaDataMember.IsDiscriminator);
			Assert.IsTrue(metaDataMember.IsPersistent);
			Assert.IsTrue(metaDataMember.IsPrimaryKey);
			Assert.IsFalse(metaDataMember.IsVersion);
			Assert.AreEqual(typeof(int), metaDataMember.Type);
			Assert.AreEqual(UpdateCheck.Always, metaDataMember.UpdateCheck);
		}

		[TestMethod]
		public void IdentityColumnViaBuilder()
		{
			var configuration = new MindboxMappingConfiguration();
			configuration.ModelBuilder.Configurations.Add(new TestEntity6.TestEntity6Configuration());

			var mappingSource = new MindboxMappingSource(configuration);
			var metaDataMember = mappingSource
				.GetModel(typeof(DataContext))
				.GetMetaType(typeof(TestEntity6))
				.DataMembers
				.SingleOrDefault(aMetaDataMember => aMetaDataMember.Name == "Id");

			Assert.IsNotNull(metaDataMember);
			Assert.AreEqual("Id", metaDataMember.MappedName);
			Assert.IsNull(metaDataMember.Association);
			Assert.AreEqual(AutoSync.OnInsert, metaDataMember.AutoSync);
			Assert.IsFalse(metaDataMember.CanBeNull);
			Assert.AreEqual("int identity not null", metaDataMember.DbType);
			Assert.IsNull(metaDataMember.Expression);
			Assert.IsFalse(metaDataMember.IsAssociation);
			Assert.IsTrue(metaDataMember.IsDbGenerated);
			Assert.IsFalse(metaDataMember.IsDeferred);
			Assert.IsFalse(metaDataMember.IsDiscriminator);
			Assert.IsTrue(metaDataMember.IsPersistent);
			Assert.IsTrue(metaDataMember.IsPrimaryKey);
			Assert.IsFalse(metaDataMember.IsVersion);
			Assert.AreEqual(typeof(int), metaDataMember.Type);
			Assert.AreEqual(UpdateCheck.Always, metaDataMember.UpdateCheck);
		}

		[TestMethod]
		public void RequiredOneWayOneToManyAssociationViaAttribute()
		{
			var configuration = new MindboxMappingConfiguration();
			var mappingSource = new MindboxMappingSource(configuration);
			var metaModel = mappingSource.GetModel(typeof(DataContext));
			var entityMetaType = metaModel.GetMetaType(typeof(TestEntity4));

			var foreignKeyMember = entityMetaType
				.DataMembers
				.SingleOrDefault(aMetaDataMember => aMetaDataMember.Name == "CreatorId");
			Assert.IsNotNull(foreignKeyMember);
			Assert.AreEqual("CreatorId", foreignKeyMember.MappedName);
			Assert.IsNull(foreignKeyMember.Association);
			Assert.AreEqual(AutoSync.Never, foreignKeyMember.AutoSync);
			Assert.IsFalse(foreignKeyMember.CanBeNull);
			Assert.AreEqual("int not null", foreignKeyMember.DbType);
			Assert.IsNull(foreignKeyMember.Expression);
			Assert.IsFalse(foreignKeyMember.IsAssociation);
			Assert.IsFalse(foreignKeyMember.IsDbGenerated);
			Assert.IsFalse(foreignKeyMember.IsDeferred);
			Assert.IsFalse(foreignKeyMember.IsDiscriminator);
			Assert.IsTrue(foreignKeyMember.IsPersistent);
			Assert.IsFalse(foreignKeyMember.IsPrimaryKey);
			Assert.IsFalse(foreignKeyMember.IsVersion);
			Assert.AreEqual(typeof(int), foreignKeyMember.Type);
			Assert.AreEqual(UpdateCheck.Always, foreignKeyMember.UpdateCheck);

			var associationMember = entityMetaType
				.DataMembers
				.SingleOrDefault(aMetaDataMember => aMetaDataMember.Name == "Creator");
			Assert.IsNotNull(associationMember);
			Assert.IsNotNull(associationMember.MappedName);
			Assert.IsNotNull(associationMember.Association);
			Assert.AreEqual(AutoSync.Never, associationMember.AutoSync);
			Assert.IsTrue(associationMember.CanBeNull);
			Assert.IsNull(associationMember.DbType);
			Assert.IsNull(associationMember.Expression);
			Assert.IsTrue(associationMember.IsAssociation);
			Assert.IsFalse(associationMember.IsDbGenerated);
			Assert.IsTrue(associationMember.IsDeferred);
			Assert.IsFalse(associationMember.IsDiscriminator);
			Assert.IsTrue(associationMember.IsPersistent);
			Assert.IsFalse(associationMember.IsPrimaryKey);
			Assert.IsFalse(associationMember.IsVersion);
			Assert.AreEqual(typeof(TestEntity4), associationMember.Type);
			Assert.AreEqual(UpdateCheck.Never, associationMember.UpdateCheck);
			Assert.IsFalse(associationMember.Association.DeleteOnNull);
			Assert.IsNull(associationMember.Association.DeleteRule);
			Assert.IsTrue(associationMember.Association.IsForeignKey);
			Assert.IsFalse(associationMember.Association.IsMany);
			Assert.IsFalse(associationMember.Association.IsNullable);
			Assert.IsFalse(associationMember.Association.IsUnique);
			Assert.IsTrue(associationMember.Association.OtherKeyIsPrimaryKey);
			Assert.IsFalse(associationMember.Association.ThisKeyIsPrimaryKey);
			Assert.IsNotNull(associationMember.Association.OtherKey);
			Assert.AreEqual(1, associationMember.Association.OtherKey.Count);
			Assert.AreEqual(entityMetaType, associationMember.Association.OtherKey[0].DeclaringType);
			Assert.AreEqual("Id", associationMember.Association.OtherKey[0].Name);
			Assert.IsNotNull(associationMember.Association.ThisKey);
			Assert.AreEqual(1, associationMember.Association.ThisKey.Count);
			Assert.AreEqual(entityMetaType, associationMember.Association.ThisKey[0].DeclaringType);
			Assert.AreEqual("CreatorId", associationMember.Association.ThisKey[0].Name);
			Assert.IsNull(associationMember.Association.OtherMember);
			Assert.AreEqual(entityMetaType, associationMember.Association.OtherType);
			Assert.AreEqual(associationMember, associationMember.Association.ThisMember);
		}

		[TestMethod]
		public void RequiredOneWayOneToManyAssociationViaBuilderWithoutDeferredLoading()
		{
			var configuration = new MindboxMappingConfiguration();
			configuration.ModelBuilder.Configurations.Add(new TestEntity6.TestEntity6Configuration());

			var mappingSource = new MindboxMappingSource(configuration);
			var metaModel = mappingSource.GetModel(typeof(DataContext));
			var entityMetaType = metaModel.GetMetaType(typeof(TestEntity6));

			var foreignKeyMember = entityMetaType
				.DataMembers
				.SingleOrDefault(aMetaDataMember => aMetaDataMember.Name == "CreatorId");
			Assert.IsNotNull(foreignKeyMember);
			Assert.AreEqual("CreatorId", foreignKeyMember.MappedName);
			Assert.IsNull(foreignKeyMember.Association);
			Assert.AreEqual(AutoSync.Never, foreignKeyMember.AutoSync);
			Assert.IsFalse(foreignKeyMember.CanBeNull);
			Assert.AreEqual("int not null", foreignKeyMember.DbType);
			Assert.IsNull(foreignKeyMember.Expression);
			Assert.IsFalse(foreignKeyMember.IsAssociation);
			Assert.IsFalse(foreignKeyMember.IsDbGenerated);
			Assert.IsFalse(foreignKeyMember.IsDeferred);
			Assert.IsFalse(foreignKeyMember.IsDiscriminator);
			Assert.IsTrue(foreignKeyMember.IsPersistent);
			Assert.IsFalse(foreignKeyMember.IsPrimaryKey);
			Assert.IsFalse(foreignKeyMember.IsVersion);
			Assert.AreEqual(typeof(int), foreignKeyMember.Type);
			Assert.AreEqual(UpdateCheck.Always, foreignKeyMember.UpdateCheck);

			var associationMember = entityMetaType
				.DataMembers
				.SingleOrDefault(aMetaDataMember => aMetaDataMember.Name == "Creator");
			Assert.IsNotNull(associationMember);
			Assert.IsNotNull(associationMember.MappedName);
			Assert.IsNotNull(associationMember.Association);
			Assert.AreEqual(AutoSync.Never, associationMember.AutoSync);
			Assert.IsTrue(associationMember.CanBeNull);
			Assert.IsNull(associationMember.DbType);
			Assert.IsNull(associationMember.Expression);
			Assert.IsTrue(associationMember.IsAssociation);
			Assert.IsFalse(associationMember.IsDbGenerated);
			Assert.IsFalse(associationMember.IsDiscriminator);
			Assert.IsTrue(associationMember.IsPersistent);
			Assert.IsFalse(associationMember.IsPrimaryKey);
			Assert.IsFalse(associationMember.IsVersion);
			Assert.AreEqual(typeof(TestEntity6), associationMember.Type);
			Assert.AreEqual(UpdateCheck.Never, associationMember.UpdateCheck);
			Assert.IsFalse(associationMember.Association.DeleteOnNull);
			Assert.IsNull(associationMember.Association.DeleteRule);
			Assert.IsTrue(associationMember.Association.IsForeignKey);
			Assert.IsFalse(associationMember.Association.IsMany);
			Assert.IsFalse(associationMember.Association.IsNullable);
			Assert.IsFalse(associationMember.Association.IsUnique);
			Assert.IsTrue(associationMember.Association.OtherKeyIsPrimaryKey);
			Assert.IsFalse(associationMember.Association.ThisKeyIsPrimaryKey);
			Assert.IsNotNull(associationMember.Association.OtherKey);
			Assert.AreEqual(1, associationMember.Association.OtherKey.Count);
			Assert.AreEqual(entityMetaType, associationMember.Association.OtherKey[0].DeclaringType);
			Assert.AreEqual("Id", associationMember.Association.OtherKey[0].Name);
			Assert.IsNotNull(associationMember.Association.ThisKey);
			Assert.AreEqual(1, associationMember.Association.ThisKey.Count);
			Assert.AreEqual(entityMetaType, associationMember.Association.ThisKey[0].DeclaringType);
			Assert.AreEqual("CreatorId", associationMember.Association.ThisKey[0].Name);
			Assert.IsNull(associationMember.Association.OtherMember);
			Assert.AreEqual(entityMetaType, associationMember.Association.OtherType);
			Assert.AreEqual(associationMember, associationMember.Association.ThisMember);
		}
	}
}