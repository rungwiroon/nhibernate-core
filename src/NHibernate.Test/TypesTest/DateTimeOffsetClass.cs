using System;
using LanguageExt;

namespace NHibernate.Test.TypesTest
{
	public class DateTimeOffsetClass
	{
		public int Id { get; set; }
		public DateTimeOffset Value { get; set; }
		public DateTimeOffset Revision { get; protected set; }
		public DateTimeOffset? NullableValue { get; set; }
		public Option<DateTimeOffset> OptionalValue { get; set; }
	}
}
