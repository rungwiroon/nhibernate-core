using LanguageExt;

namespace NHibernate.Test.TypesTest
{
	public class CharClass
	{
		public int Id { get; set; }
		public virtual char NormalChar { get; set; }
		public virtual char? NullableChar { get; set; }
		public virtual Option<char> OptionChar { get; set; }
	}
}
