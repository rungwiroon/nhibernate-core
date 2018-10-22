using System;
using LanguageExt;

namespace NHibernate.Test.TypesTest
{
	public class DateTimeClass
	{
		public int Id { get; set; }
		public DateTime Value { get; set; }
		public DateTime Revision { get; protected set; }
		public DateTime? NullableValue { get; set; }
		public Option<DateTime> OptionalValue { get; set; }
	}
}
