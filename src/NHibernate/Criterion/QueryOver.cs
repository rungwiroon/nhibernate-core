
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using NHibernate.Impl;
using NHibernate.SqlCommand;

namespace NHibernate.Criterion
{

	/// <summary>
	/// Implementation of the <see cref="ICriteria&lt;T&gt;"/> interface
	/// </summary>
	[Serializable]
	public class QueryOver<T> : ICriteria<T>
	{

		private ICriteria		_criteria;
		private CriteriaImpl	_impl;

		public QueryOver()
		{
			_impl = new CriteriaImpl(typeof(T), null);
			_criteria = _impl;
		}

		public QueryOver(CriteriaImpl impl)
		{
			_impl = impl;
			_criteria = impl;
		}

		public QueryOver(CriteriaImpl rootImpl, ICriteria criteria)
		{
			_impl = rootImpl;
			_criteria = criteria;
		}

		public ICriteria UnderlyingCriteria
		{
			get { return _criteria; }
		}

		public ICriteria<T> And(Expression<Func<T, bool>> expression)
		{
			return Add(expression);
		}

		public ICriteria<T> And(Expression<Func<bool>> expression)
		{
			return Add(expression);
		}

		public ICriteria<T> Where(Expression<Func<T, bool>> expression)
		{
			return Add(expression);
		}

		public ICriteria<T> Where(Expression<Func<bool>> expression)
		{
			return Add(expression);
		}

		public ICriteria<U> JoinWalk<U>(Expression<Func<T, U>> path)
		{
			return new QueryOver<U>(_impl,
				_criteria.CreateCriteria(
					ExpressionProcessor.FindMemberExpression(path.Body)));
		}

		public ICriteria<U> JoinWalk<U>(Expression<Func<T, IEnumerable<U>>> path)
		{
			return new QueryOver<U>(_impl,
				_criteria.CreateCriteria(
					ExpressionProcessor.FindMemberExpression(path.Body)));
		}

		public ICriteria<T> Join(Expression<Func<T, object>> path, Expression<Func<object>> alias)
		{
			return AddAlias(
				ExpressionProcessor.FindMemberExpression(path.Body),
				ExpressionProcessor.FindMemberExpression(alias.Body),
				JoinType.InnerJoin);
		}

		public IList<T> List()
		{
			return _criteria.List<T>();
		}

		public ICriteria<T> GetExecutableQueryOver(ISession session)
		{
			_impl.Session = session.GetSessionImplementation();
			return this;
		}

		private QueryOver<T> AddAlias(string path, string alias, JoinType joinType)
		{
			_criteria.CreateAlias(path, alias, joinType);
			return this;
		}

		private QueryOver<T> Add(Expression<Func<T, bool>> expression)
		{
			_criteria.Add(ExpressionProcessor.ProcessExpression<T>(expression));
			return this;
		}

		private QueryOver<T> Add(Expression<Func<bool>> expression)
		{
			_criteria.Add(ExpressionProcessor.ProcessExpression(expression));
			return this;
		}

	}

}
