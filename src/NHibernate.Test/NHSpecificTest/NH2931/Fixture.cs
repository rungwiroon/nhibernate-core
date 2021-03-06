﻿using System;
using NHibernate.Mapping.ByCode;
using NUnit.Framework;
using System.Linq;

namespace NHibernate.Test.NHSpecificTest.NH2931
{
	[TestFixture]
	public class MappingByCodeTest
	{
		[Test]
		public void CompiledMappings_ShouldNotDependOnAddedOrdering_AddedBy_AddMapping()
		{
			var mapper = new ModelMapper();
			mapper.AddMapping<EntityMapping>();
			mapper.AddMapping<DerivedClassMapping>();
			mapper.AddMapping<BaseClassMapping>();
			var config = TestConfigurationHelper.GetDefaultConfiguration();
			Assert.DoesNotThrow(() => config.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities()));
		}

		[Test]
		public void CompiledMappings_ShouldNotDependOnAddedOrdering_AddedBy_AddMappings()
		{
			var mapper = new ModelMapper();
			mapper.AddMappings(typeof(EntityMapping).Assembly
				.GetExportedTypes()
				//only add our test entities/mappings
				.Where(t => t.Namespace == typeof(MappingByCodeTest).Namespace));
			var config = TestConfigurationHelper.GetDefaultConfiguration();
			Assert.DoesNotThrow(() => config.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities()));
		}
	}
}
