using System;

namespace Mvno.TestHelpers
{
	public abstract class BehaviorTesting<TClassUnderTest>: Testing<TClassUnderTest>
		where TClassUnderTest : class
	{
		protected Exception CaughtException
		{
			get;
			private set;
		}

		public BehaviorTesting()
		{
			Given();

			try
			{
				When();
			}
			catch (Exception exception)
			{
				CaughtException = exception;
			}
			finally
			{
				Finally();
			}
		}

		protected abstract void When();

		protected virtual void Given()
		{
		}

		protected virtual void Finally()
		{
		}
	}
}